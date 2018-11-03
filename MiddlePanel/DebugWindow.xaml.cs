using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MiddlePanel.Helpers;
using MiddlePanel.Model;

namespace MiddlePanel
{
    /// <summary>
    /// Логика взаимодействия для DebugWindow.xaml
    /// </summary>
    public partial class DebugWindow : Window
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void MkSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("mk1", new Parameter ("mk1", MkSlider.Value));
            Mediator.Instance.NotifyColleagues<object>("mk2", new Parameter("mk2", MkSlider.Value));
        }

        private void TmtSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("tmt1", new Parameter("tmt1", TmtSlider.Value * 1000 / 10));
            Mediator.Instance.NotifyColleagues<object>("tmt2", new Parameter("tmt2", TmtSlider.Value * 1000 / 10));
        }

        private void rpm1Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("ng1", new Parameter("ng1", rpm1Slider.Value * 100 / 10));
            Mediator.Instance.NotifyColleagues<object>("ng2", new Parameter("ng2", rpm1Slider.Value * 100 / 10));
        }

        private void rpm2Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("nv1", new Parameter("nv1", rpm2Slider.Value * 2700 / 10));
            Mediator.Instance.NotifyColleagues<object>("nv2", new Parameter("nv2", rpm2Slider.Value * 2700 / 10));
        }

        private void fpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("pt1", new Parameter("pt1", fpSlider.Value * 16 / 10));
            Mediator.Instance.NotifyColleagues<object>("pt2", new Parameter("pt2", fpSlider.Value * 16 / 10));
        }

        private void olpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("po1", new Parameter("po1", olpSlider.Value * 4 / 10));
            Mediator.Instance.NotifyColleagues<object>("po2", new Parameter("po2", olpSlider.Value * 4 / 10));
        }

        private void oltSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("to1", new Parameter("to1", oltSlider.Value * 120 / 10));
            Mediator.Instance.NotifyColleagues<object>("to2", new Parameter("to2", oltSlider.Value * 120 / 10));
        }

        private void fuelSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Mediator.Instance.NotifyColleagues<object>("gp1", new Parameter("gp1", fuelSlider.Value * 500 / 10));
            Mediator.Instance.NotifyColleagues<object>("gp2", new Parameter("gp2", fuelSlider.Value * 500 / 10));
        }

        private void aproxTestButton_Click(object sender, RoutedEventArgs e)
        {
            Task aproxTask = new Task(()=> {
                int step = 0;
                double stepValue = 0;
                while (step < 100)
                {
                    stepValue = stepValue + 10;          
                    Mediator.Instance.NotifyColleagues<object>("mk1", new Parameter("mk1", stepValue));
                    Mediator.Instance.NotifyColleagues<object>("mk2", new Parameter("mk2", stepValue));
                    step = step + 1;
                    Thread.Sleep(60);
                }
            });
            aproxTask.Start();
        }
    }
}
