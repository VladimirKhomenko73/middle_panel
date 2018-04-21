using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using MiddlePanel.Helpers;
using MiddlePanel.Model;
using MiddlePanel.Net;

namespace MiddlePanel
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private Communicator communicator;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            List<Screen> allScreensList = Screen.AllScreens.ToList();


            MainWindow window = new MainWindow();
#if !DEBUG
            if (allScreensList.Count > 1)
            {
                for (int i = 0; i < allScreensList.Count; i = i + 1)
                {
                    if (allScreensList[i].WorkingArea.X > 0)
                    {
                        Rectangle workingArea = allScreensList[i].WorkingArea;
                        window.Top = workingArea.Top;
                        window.Left = workingArea.Left;
                    }
                }
            }
#endif
            window.Show();
            window.WindowState = WindowState.Maximized;
#if DEBUG
            DebugWindow debugWindow = new DebugWindow();
            debugWindow.Show();
#endif

#if !DEBUG
            communicator = new Communicator();
            communicator.Start();
#endif


        }
    }
}
