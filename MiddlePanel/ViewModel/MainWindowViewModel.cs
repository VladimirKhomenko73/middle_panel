using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiddlePanel.Helpers;
using MiddlePanel.Model;

namespace MiddlePanel.ViewModel
{
    public class MainWindowViewModel : INPCBase
    {
        private double ngLValue;
        private double ngRValue;
        private double nvLValue;
        private double nvRValue;
        private double tmtLValue;
        private double tmtRValue;
        private double mkLValue;
        private double mkRValue;
        private double poLValue;
        private double poRValue;
        private double toLValue;
        private double toRValue;
        private double gpLValue;
        private double gpRValue;
        private double ptLValue;
        private double ptRValue;

        private Parameter ngLParameterValue;
        private Parameter ngRParameterValue;
        private Parameter nvLParameterValue;
        private Parameter nvRParameterValue;
        private Parameter tmtLParameterValue;
        private Parameter tmtRParameterValue;
        private Parameter mkLParameterValue;
        private Parameter mkRParameterValue;
        private Parameter poLParameterValue;
        private Parameter poRParameterValue;
        private Parameter toLParameterValue;
        private Parameter toRParameterValue;
        private Parameter gpLParameterValue;
        private Parameter gpRParameterValue;
        private Parameter ptLParameterValue;
        private Parameter ptRParameterValue;

        public MainWindowViewModel()
        {
            Mediator.Instance.Register(this);
        }

        #region Parameter properties
        
        private Parameter ngLParameter
        {
            get { return ngLParameterValue; }
            set
            {
                ngLParameterValue = value;
                ngLAngle = value.GetValueAsDouble();

            }
        }

        private Parameter ngRParameter
        {
            get { return ngRParameterValue; }
            set
            {
                ngRParameterValue = value;
                ngRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter nvLParameter
        {
            get { return nvLParameterValue; }
            set
            {
                nvLParameterValue = value;
                nvLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter nvRParameter
        {
            get { return nvRParameterValue; }
            set
            {
                nvRParameterValue = value;
                nvRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter tmtLParameter
        {
            get { return tmtLParameterValue; }
            set
            {
                tmtLParameterValue = value;
                tmtLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter tmtRParameter
        {
            get { return tmtRParameterValue; }
            set
            {
                tmtRParameterValue = value;
                tmtRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter mkLParameter
        {
            get { return mkLParameterValue; }
            set
            {
                mkLParameterValue = value;
                mkLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter mkRParameter
        {
            get { return mkRParameterValue; }
            set
            {
                mkRParameterValue = value;
                mkRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter poLParameter
        {
            get { return poLParameterValue; }
            set
            {
                poLParameterValue = value;
                poLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter poRParameter
        {
            get { return poRParameterValue; }
            set
            {
                poRParameterValue = value;
                poRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter toLParameter
        {
            get { return toLParameterValue; }
            set
            {
                toLParameterValue = value;
                toLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter toRParameter
        {
            get { return toRParameterValue; }
            set
            {
                toRParameterValue = value;
                toRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter gpLParameter
        {
            get { return gpLParameterValue; }
            set
            {
                gpLParameterValue = value;
                gpLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter gpRParameter
        {
            get { return gpRParameterValue; }
            set
            {
                gpRParameterValue = value;
                gpRAngle = value.GetValueAsDouble();

            }
        }
        private Parameter ptLParameter
        {
            get { return ptLParameterValue; }
            set
            {
                ptLParameterValue = value;
                ptLAngle = value.GetValueAsDouble();

            }
        }
        private Parameter ptRParameter
        {
            get { return ptRParameterValue; }
            set
            {
                ptRParameterValue = value;
                ptRAngle = value.GetValueAsDouble();

            }
        }

        #endregion

        #region Angle Values

        public double ngLAngle
        {
            get { return ngLValue; }
            set
            {
                if (value > 20)
                {
                    if (value > 60)
                    {
                        if (value > 110)
                        {
                            ngLValue = 330.17;
                        }
                        else
                        {
                            ngLValue = 148.766 + (value - 50) * 3.0234;
                        }
                        
                    }
                    else
                    {
                        ngLValue = 59.2 + (value - 20) * 2.9833;
                    }
                }
                else
                {
                    ngLValue = value * 2.9546;
                }
                OnPropertyChanged("ngLAngle");
            }
        }

        public double ngRAngle
        {
            get { return ngRValue; }
            set
            {
                if (value > 20)
                {
                    if (value > 60)
                    {
                        if (value > 110)
                        {
                            ngRValue = 330.17;
                        }
                        else
                        {
                            ngRValue = 148.766 + (value - 50) * 3.0234;
                        }

                    }
                    else
                    {
                        ngRValue = 59.2 + (value - 20) * 2.9833;
                    }
                }
                else
                {
                    ngRValue = value * 2.9546;
                }
                OnPropertyChanged("ngRAngle");
            }
        }
        public double nvLAngle
        {
            get { return nvLValue; }
            set
            {
                double calibratedValue = value / 100;
                if (calibratedValue > 10)
                {
                    if (calibratedValue > 15)
                    {
                        if (calibratedValue > 25)
                        {
                            nvLValue = 300;
                        }
                        else
                        {
                            nvLValue = 180.2 + (calibratedValue - 15) * 11.98;
                        }
                    }
                    else
                    {
                        nvLValue = 120.1 + (calibratedValue - 10) * 12.02;
                    }
                }
                else
                {
                    nvLValue = calibratedValue * 11.9896;
                }
                OnPropertyChanged("nvLAngle");
            }
        }

        public double nvRAngle
        {
            get { return nvRValue; }
            set
            {
                double calibratedValue = value / 100;
                if (calibratedValue > 10)
                {
                    if (calibratedValue > 15)
                    {
                        if (calibratedValue > 25)
                        {
                            nvRValue = 300;
                        }
                        else
                        {
                            nvRValue = 180.2 + (calibratedValue - 15) * 11.98;
                        }
                    }
                    else
                    {
                        nvRValue = 120.1 + (calibratedValue - 10) * 12.02;
                    }
                }
                else
                {
                    nvRValue = calibratedValue * 11.9896;
                }
                OnPropertyChanged("nvRAngle");
            }
        }
        public double tmtLAngle
        {
            get { return tmtLValue; }
            set
            {
                double calibratedValue = value / 10;
                if (calibratedValue > 10)
                {
                    if (calibratedValue > 20)
                    {
                        if (calibratedValue > 30)
                        {
                            if (calibratedValue > 40)
                            {
                                if (calibratedValue > 50)
                                {
                                    if (calibratedValue > 60)
                                    {
                                        if (calibratedValue > 70)
                                        {
                                            if (calibratedValue > 80)
                                            {
                                                if (calibratedValue > 90)
                                                {
                                                    tmtLValue = 187.222;
                                                }
                                                else
                                                {
                                                    tmtLValue = 166.317 + (calibratedValue - 80) * 2.0905;
                                                }
                                            }
                                            else
                                            {
                                                tmtLValue = 144.993 + (calibratedValue - 70) * 2.1324;
                                            }
                                        }
                                        else
                                        {
                                            tmtLValue = 123.66 + (calibratedValue - 60) * 2.1333;
                                        }
                                    }
                                    else
                                    {
                                        tmtLValue = 102.136 + (calibratedValue - 50) * 2.1524;
                                    }
                                }
                                else
                                {
                                    tmtLValue = 80.388 + (calibratedValue - 40) * 2.1748;
                                }
                            }
                            else
                            {
                                tmtLValue = 59.41 + (calibratedValue - 30) * 2.0978;
                            }
                        }
                        else
                        {
                            tmtLValue = 38.17 + (calibratedValue - 20) * 2.124;
                        }
                    }
                    else
                    {
                        tmtLValue = 18.88 + (calibratedValue - 10) * 1.929;
                    }
                }
                else
                {
                    tmtLValue = calibratedValue * 1.888;
                }

                OnPropertyChanged("tmtLAngle");
            }
        }

        public double tmtRAngle
        {
            get { return tmtRValue; }
            set
            {
                double calibratedValue = value / 10;
                if (calibratedValue > 10)
                {
                    if (calibratedValue > 20)
                    {
                        if (calibratedValue > 30)
                        {
                            if (calibratedValue > 40)
                            {
                                if (calibratedValue > 50)
                                {
                                    if (calibratedValue > 60)
                                    {
                                        if (calibratedValue > 70)
                                        {
                                            if (calibratedValue > 80)
                                            {
                                                if (calibratedValue > 90)
                                                {
                                                    tmtRValue = 187.222;
                                                }
                                                else
                                                {
                                                    tmtRValue = 166.317 + (calibratedValue - 80) * 2.0905;
                                                }
                                            }
                                            else
                                            {
                                                tmtRValue = 144.993 + (calibratedValue - 70) * 2.1324;
                                            }
                                        }
                                        else
                                        {
                                            tmtRValue = 123.66 + (calibratedValue - 60) * 2.1333;
                                        }
                                    }
                                    else
                                    {
                                        tmtRValue = 102.136 + (calibratedValue - 50) * 2.1524;
                                    }
                                }
                                else
                                {
                                    tmtRValue = 80.388 + (calibratedValue - 40) * 2.1748;
                                }
                            }
                            else
                            {
                                tmtRValue = 59.41 + (calibratedValue - 30) * 2.0978;
                            }
                        }
                        else
                        {
                            tmtRValue = 38.17 + (calibratedValue - 20) * 2.124;
                        }
                    }
                    else
                    {
                        tmtRValue = 18.88 + (calibratedValue - 10) * 1.929;
                    }
                }
                else
                {
                    tmtRValue = calibratedValue * 1.888;
                }

                OnPropertyChanged("tmtRAngle");
            }
        }
        public double mkLAngle
        {
            get { return mkLValue; }
            set
            {
                if (value > 10)
                {
                    if (value > 20)
                    {
                        if (value > 30)
                        {
                            if (value > 40)
                            {
                                if (value > 50)
                                {
                                    if (value > 60)
                                    {
                                        if (value > 70)
                                        {
                                            if (value > 80)
                                            {
                                                if (value > 90)
                                                {
                                                    if (value > 100)
                                                    {
                                                        if (value > 110)
                                                        {
                                                            if (value > 120)
                                                            {
                                                                mkLValue = 257.65;
                                                            }
                                                            else
                                                            {
                                                                mkLValue = 235.788 + (value - 110) * 2.1862;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            mkLValue = 215.415 + (value - 100) * 2.0373;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        mkLValue = 193.983 + (value - 90) * 2.1432;
                                                    }
                                                }
                                                else
                                                {
                                                    mkLValue = 172.614 + (value - 80) * 2.1369;
                                                }
                                            }
                                            else
                                            {
                                                mkLValue = 150.503 + (value - 70) * 2.2111;
                                            }
                                        }
                                        else
                                        {
                                            mkLValue = 129.091 + (value - 60) * 2.1412;
                                        }
                                    }
                                    else
                                    {
                                        mkLValue = 107.057 + (value - 50) * 2.2034;
                                    }
                                }
                                else
                                {
                                    mkLValue = 84.902 + (value - 40) * 2.2115;
                                }
                            }
                            else
                            {
                                mkLValue = 63.86 + (value - 30) * 2.1042;
                            }
                        }
                        else
                        {
                            mkLValue = 42.64 + (value - 20) * 2.122;
                        }
                    }
                    else
                    {
                        mkLValue = 21.176 + (value - 10) * 2.1464;
                    }
                }
                else
                {
                    mkLValue = value * 2.1176;
                }
                
                OnPropertyChanged("mkLAngle");
            }
        }

        public double mkRAngle
        {
            get { return mkRValue; }
            set
            {
                if (value > 10)
                {
                    if (value > 20)
                    {
                        if (value > 30)
                        {
                            if (value > 40)
                            {
                                if (value > 50)
                                {
                                    if (value > 60)
                                    {
                                        if (value > 70)
                                        {
                                            if (value > 80)
                                            {
                                                if (value > 90)
                                                {
                                                    if (value > 100)
                                                    {
                                                        if (value > 110)
                                                        {
                                                            if (value > 120)
                                                            {
                                                                mkRValue = 257.65;
                                                            }
                                                            else
                                                            {
                                                                mkRValue = 235.788 + (value - 110) * 2.1862;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            mkRValue = 215.415 + (value - 100) * 2.0373;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        mkRValue = 193.983 + (value - 90) * 2.1432;
                                                    }
                                                }
                                                else
                                                {
                                                    mkRValue = 172.614 + (value - 80) * 2.1369;
                                                }
                                            }
                                            else
                                            {
                                                mkRValue = 150.503 + (value - 70) * 2.2111;
                                            }
                                        }
                                        else
                                        {
                                            mkRValue = 129.091 + (value - 60) * 2.1412;
                                        }
                                    }
                                    else
                                    {
                                        mkRValue = 107.057 + (value - 50) * 2.2034;
                                    }
                                }
                                else
                                {
                                    mkRValue = 84.902 + (value - 40) * 2.2115;
                                }
                            }
                            else
                            {
                                mkRValue = 63.86 + (value - 30) * 2.1042;
                            }
                        }
                        else
                        {
                            mkRValue = 42.64 + (value - 20) * 2.122;
                        }
                    }
                    else
                    {
                        mkRValue = 21.176 + (value - 10) * 2.1464;
                    }
                }
                else
                {
                    mkRValue = value * 2.1176;
                }

                OnPropertyChanged("mkRAngle");
            }
        }
        public double poLAngle
        {
            get { return poLValue; }
            set
            {
                if (value > 4)
                {
                    poLValue = -100.11;
                }
                else
                {
                    poLValue = value * (-25);
                }
                OnPropertyChanged("poLAngle");
            }
        }

        public double poRAngle
        {
            get { return poRValue; }
            set
            {
                if (value > 4)
                {
                    poRValue = -100.11;
                }
                else
                {
                    poRValue = value * (-25);
                }
                OnPropertyChanged("poRAngle");
            }
        }
        public double toLAngle
        {
            get { return toLValue; }
            set
            {
                double calibratedValue = value / 10;
                if (calibratedValue > 0)
                {
                    if (calibratedValue > 12)
                    {
                        toLValue = 101.593;
                    }
                    else
                    {
                        toLValue = 23.323 + calibratedValue * 6.3;
                    }
                }
                else
                {
                    toLValue = 23.323 + (calibratedValue * 6.3);
                }                
                OnPropertyChanged("toLAngle");
            }
        }

        public double toRAngle
        {
            get { return toRValue; }
            set
            {
                double calibratedValue = value / 10;
                if (calibratedValue > 0)
                {
                    if (calibratedValue > 12)
                    {
                        toRValue = 101.593;
                    }
                    else
                    {
                        toRValue = 23.323 + calibratedValue * 6.3;
                    }
                }
                else
                {
                    toRValue = 23.323 + (calibratedValue * 6.3);
                }
                OnPropertyChanged("toRAngle");
            }
        }
        public double gpLAngle
        {
            get { return gpLValue; }
            set
            {
                double calibratedValue = value / 100;
                if (calibratedValue > 1)
                {
                    gpLValue = 47.31 + (calibratedValue - 1) * 49.048;
                }
                else
                {
                    gpLValue = calibratedValue * 47.31;
                }
                OnPropertyChanged("gpLAngle");
            }
        }

        public double gpRAngle
        {
            get { return gpRValue; }
            set
            {
                double calibratedValue = value / 100;
                if (calibratedValue > 1)
                {
                    gpRValue = 47.31 + (calibratedValue - 1) * 49.048;
                }
                else
                {
                    gpRValue = calibratedValue * 47.31;
                }
                OnPropertyChanged("gpRAngle");
            }
        }
        public double ptLAngle
        {
            get { return ptLValue; }
            set
            {
                if (value > 0)
                {
                    if (value > 16)
                    {
                        ptLValue = 91.687;
                    }
                    else
                    {
                        ptLValue = 1.933 + value * 5.609625;
                    }
                }
                else
                {
                    ptLValue = 1.933;
                }
                OnPropertyChanged("ptLAngle");
            }
        }

        public double ptRAngle
        {
            get { return ptRValue; }
            set
            {
                if (value > 0)
                {
                    if (value > 16)
                    {
                        ptRValue = 91.687;
                    }
                    else
                    {
                        ptRValue = 1.933 + value * 5.609625;
                    }
                }
                else
                {
                    ptRValue = 1.933;
                }
                OnPropertyChanged("ptRAngle");
            }
        }

        #endregion

        #region Registration Area
        [MediatorMessageSink("ng1")]
        private void ngLParameterUpdate(object updateParameter)
        {
            ngLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("ng2")]
        private void ngRParameterUpdate(object updateParameter)
        {
            ngRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("nv1")]
        private void nvLParameterUpdate(object updateParameter)
        {
            nvLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("nv2")]
        private void nvRParameterUpdate(object updateParameter)
        {
            nvRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("tmt1")]
        private void tmtLParameterUpdate(object updateParameter)
        {
            tmtLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("tmt2")]
        private void tmtRParameterUpdate(object updateParameter)
        {
            tmtRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("mk1")]
        private void mkLParameterUpdate(object updateParameter)
        {
            mkLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("mk2")]
        private void mkRParameterUpdate(object updateParameter)
        {
            mkRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("po1")]
        private void poLParameterUpdate(object updateParameter)
        {
            poLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("po2")]
        private void poRParameterUpdate(object updateParameter)
        {
            poRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("to1")]
        private void toLParameterUpdate(object updateParameter)
        {
            toLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("to2")]
        private void toRParameterUpdate(object updateParameter)
        {
            toRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("gp1")]
        private void gpLParameterUpdate(object updateParameter)
        {
            gpLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("gp2")]
        private void gpRParameterUpdate(object updateParameter)
        {
            gpRParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("pt1")]
        private void ptLParameterUpdate(object updateParameter)
        {
            ptLParameter = (Parameter)updateParameter;
        }
        [MediatorMessageSink("pt2")]
        private void ptRParameterUpdate(object updateParameter)
        {
            ptRParameter = (Parameter)updateParameter;
        }
        #endregion
    }
}
