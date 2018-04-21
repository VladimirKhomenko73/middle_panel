using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MiddlePanel.Helpers;
using MiddlePanel.Model;

namespace MiddlePanel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
            this.Close();
        }

        /*For gauge testing*/
        //private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        //{
        //    Mediator.Instance.NotifyColleagues<Parameter>("mk1", new Parameter("mk1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("mk2", new Parameter("mk2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("tmt1", new Parameter("tmt1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("tmt2", new Parameter("tmt2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("ng1", new Parameter("ng1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("ng2", new Parameter("ng2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("nv1", new Parameter("nv1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("nv2", new Parameter("nv2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("gp1", new Parameter("gp1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("gp2", new Parameter("gp2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("pt1", new Parameter("pt1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("pt2", new Parameter("pt2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("po1", new Parameter("po1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("po2", new Parameter("po2", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("to1", new Parameter("to1", slider.Value));
        //    Mediator.Instance.NotifyColleagues<Parameter>("to2", new Parameter("to2", slider.Value));
        //}
    }
}
