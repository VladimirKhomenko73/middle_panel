using System;

namespace MiddlePanel.Model
{
    public class Parameter
    {
        private string parameterName;
        private object parameterValue;
        private DateTime parameterUpdateTime;


        #region Constructors
        public Parameter()
        {

        }

        public Parameter(string name, object value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, int value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, double value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, float value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, bool value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, string value)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public Parameter(string name, object value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        public Parameter(string name, int value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        public Parameter(string name, double value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        public Parameter(string name, float value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        public Parameter(string name, bool value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        public Parameter(string name, string value, DateTime time)
        {
            parameterName = name;
            parameterValue = value;
            parameterUpdateTime = time;
        }

        #endregion

        #region GetProperty

        public string GetName()
        {
            return parameterName;
        }

        public object GetValue()
        {
            return parameterValue;
        }

        #endregion

        #region GetPropertyAs

        public int GetValueAsInt()
        {
            return Convert.ToInt32(parameterValue);
        }

        public double GetValueAsDouble()
        {
            return Convert.ToDouble(parameterValue);
        }

        public float GetValueAsFloat()
        {
            return Convert.ToSingle(parameterValue);
        }

        public bool GetValueAsBool()
        {
            return Convert.ToBoolean(parameterValue);
        }

        public string GetValueAsString()
        {
            return parameterValue.ToString();
        }

        #endregion

        #region SetValue

        public void SetValue(object value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public void SetValue(int value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }
        public void SetValue(double value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public void SetValue(float value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public void SetValue(bool value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        public void SetValue(string value)
        {
            parameterValue = value;
            parameterUpdateTime = DateTime.Now;
        }

        #endregion

    }
}
