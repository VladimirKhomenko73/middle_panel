using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading;
using UdpTransceiver;
using MiddlePanel.Helpers;
using MiddlePanel.Model;

namespace MiddlePanel.Net
{
    /// Перечислимые типы
    /// <summary>
    /// Состояния коммуникатора
    /// </summary>
    public enum CommunicatorState { stoped, active }

    /// <summary>
    /// Класс-параметр обмена
    /// </summary>
    [Serializable()]
    public class InputPackage
    {
        /// <summary>
        /// Размер пакета
        /// </summary>
        public ushort Size;
        public IPEndPoint RemoteIpEndPoint;
        /// <summary>
        /// Содержимое последнего пакета
        /// </summary>
        public byte[] Package;
        /// <summary>
        /// Время приема 
        /// </summary>
        public DateTime ReceivingTime;
        /// <summary>
        /// Порядковый номер пакета
        /// </summary>
        public Int64 PackCounter = 0;
        /// <summary>
        /// IP-адрес, с которого пришел пакет
        /// </summary>
        public IPAddress SourceIP;
        /// <summary>
        /// IP-адрес назначения пакета
        /// </summary>
        public IPAddress DestinationIP;
        /// <summary>
        /// Порт, с которого пришел последний пакет
        /// </summary>
        public int SourcePort;
        /// <summary>
        /// Порт назначения пакета
        /// </summary>
        public int DestinationPort;
        /// <summary>
        /// Источник, с которого пришло последнее обновление
        /// <summary>
        /// Конструктор объекта- контейнера 
        /// </summary>
        /// <param name="Name">Имя параметра</param>
        /// <param name="Direction">Вид параметра по направлению передачи</param>
        public InputPackage(ushort size)
        {
            this.Package = new byte[65535];
        }
    }

    /// <summary>
    /// Класс - коммуникатор. Обеспечивает обмен приложения с приложениями на удаленных узлах
    /// </summary>
    public class Communicator
    {
        /// <summary>
        /// Параметры соединения коммуникатора
        /// </summary>
        public IPAddress localIP;
        public IPAddress remoteIP;
        public int localReceivingPort;
        public int remoteSendingPort;

        public ushort inputPackageSize;

        public InputPackage InputPackage;

        public CommunicatorState state;

        private UDPTransceiver transceiver;

        private delegate void delTransmitter(UDPDatagram Datagram);


        /// <summary>
        /// Поток для работы коммуниктора
        /// </summary>
        Thread ReceiverThread;
        /// <summary>
        /// Список параметров, которыми обменивается коммуникатор
        /// </summary>

        /// <summary>
        /// Конструктор коммуникатора
        /// </summary>
        public Communicator()
        {
            localIP = IPAddress.Parse(Properties.Settings.Default.localIP);
            remoteIP = IPAddress.Parse(Properties.Settings.Default.remoteIP);
            localReceivingPort = Convert.ToInt16(Properties.Settings.Default.localReceivingPort);
            remoteSendingPort = Convert.ToInt16(Properties.Settings.Default.remoteSendingPort);

            inputPackageSize = Convert.ToUInt16(Properties.Settings.Default.inputPackageSize);
            this.InputPackage = new InputPackage(inputPackageSize);

            state = CommunicatorState.stoped;

            state = CommunicatorState.stoped;

            DataReceived += new EventHandler<EventArgs>(NotifyMediator);

            // Создаем поток для работы обменника
            ReceiverThread = new Thread(ListenNetwork);
        }


        /// <summary>
        /// Запускает в работу обменник
        /// </summary>
        public void Start()
        {
            if (transceiver == null)
            {
                transceiver = new UDPTransceiver(localIP, localReceivingPort, remoteIP, remoteSendingPort);
            }
            ReceiverThread = new Thread(ListenNetwork);
            state = CommunicatorState.active;
            ReceiverThread.IsBackground = true;

            if (!ReceiverThread.IsAlive)
                ReceiverThread.Start();
        }

        /// <summary>
        /// Останавливает работу обменника
        /// </summary>
        public void Stop()
        {
            state = CommunicatorState.stoped;
            ReceiverThread.Abort();
        }

        /// <summary>
        /// Принимает пакеты от ВИАВ
        /// </summary>
        private void ListenNetwork()
        {
            while (state == CommunicatorState.active)
            {
                //Получаем датаграмму
                InputPackage.Package = transceiver.Recieve();

                //Если пришел пакет - сохраняем тело и атрибуты
                if (InputPackage.Package.Length > 0)
                {
                    lock (this.InputPackage)
                    {
                        this.InputPackage.PackCounter++;
                        this.InputPackage.ReceivingTime = DateTime.Now;
                    }
                }

                OnDataReceived(EventArgs.Empty);

            }
        }

        private IDictionary<string, object> ParsePackage(InputPackage package)
        {
            IDictionary<string, object> inputParameters = new Dictionary<string, object>();

            string packageContent = System.Text.Encoding.ASCII.GetString(package.Package);
            //"{\"h\":{\"s\":\"VIT\",\"d\":\"INS\",\"t\":3.016369},\"p\":{\"vp\":100.000000,\"vy\":4.000000}}"

            #region 1ms
            int beginIndex = packageContent.IndexOf("\"p\":{") + 5;
            packageContent = packageContent.Remove(0, beginIndex);
            packageContent = packageContent.Remove(packageContent.Length - 2);
            string[] array = packageContent.Split(',');
            for (int i = 0; i < array.Length; i = i + 1)
            {
                string temp = array[i].Replace("\"", string.Empty);
                string[] tempArray = temp.Split(':');
                double value;
                if (Double.TryParse(tempArray[1], NumberStyles.Any, CultureInfo.InvariantCulture, out value) == true)
                {
                    inputParameters.Add(tempArray[0], value);
                }
                else
                {
                    Console.WriteLine("Bad parameter '{0}' value: {1}", tempArray[0], tempArray[1]);
                }
            }
            #endregion


            return inputParameters;
        }

        private void NotifyMediator(object sender, EventArgs e)
        {
            IDictionary<string, object> notifyParameters = ParsePackage(InputPackage);
            foreach (KeyValuePair<string, object> param in notifyParameters)
            {
                Mediator.Instance.NotifyColleagues<object>(param.Key, new Parameter(param.Key,param.Value));
            }
        }

        public event EventHandler<EventArgs> DataReceived;
        public event EventHandler<EventArgs> DataSent;

        public void OnDataReceived(EventArgs e)
        {
            if (DataReceived != null)
                DataReceived(this, e);
        }

        public void OnDataSent(EventArgs e)
        {
            if (DataSent != null)
                DataSent(this, e);
        }

    }
}
