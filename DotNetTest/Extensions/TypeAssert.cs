using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Extensions
{
    public static class TypeAssert
    {
        public static bool IsNumber(this object value)
        {
            if (value is int)
                return true;
            try
            {
                int.Parse(value.ToString());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsDateTime(this object value, string format = "dd/MM/yyyy")
        {
            if (value is DateTime)
                return ((DateTime)value) != DateTime.MinValue;
            try
            {
                DateTime.ParseExact(value.ToString() ?? "", "dd/MM/yyyy", System.Globalization.DateTimeFormatInfo.CurrentInfo, System.Globalization.DateTimeStyles.None);
                return true;
            }
            catch
            {
                return false;   
            }
        }
    }
}
