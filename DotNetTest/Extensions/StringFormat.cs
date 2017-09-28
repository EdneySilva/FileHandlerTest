using DotNetTest.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNetTest.Extensions
{    
    public static class StringFormat
    {
        public static string RemoveFormats(this string value)
        {
            return Regex.Replace(value, "[^0-9a-zA-Z ]+", "");
        }

        public static string ToSimpleUpperText(this string value)
        {
            SimpleString simpleString = new SimpleString(value);

            simpleString.ParseText((index, charValue) =>
            {
                if (charValue == ' ')
                    return true;
                if (!Regex.IsMatch(charValue.ToString(), "^[A-Za-z ]+$"))
                    return false;
                return true;
            });
            string result = simpleString;
            return result?.ToUpper();
        }

        public static string ToSimpleLowerText(this string value)
        {
            SimpleString simpleString = new SimpleString(value);

            simpleString.ParseText((index, charValue) =>
            {
                if (charValue == ' ')
                    return true;
                if (!Regex.IsMatch(charValue.ToString(), "^[0-9A-Za-z ]+$"))
                    return false;
                return true;
            });
            string result = simpleString;
            return result?.ToLower();
        }

        public static string ToCpf(this string value)
        {
            value = value.Trim();
            return !value.Length.Equals("00000000000".Length) ? value : value.Insert(3, ".").Insert(7, ".").Insert(11, "-");
        }

        public static string ToDateTime(this string value)
        {
            value = value.Trim();
            return !value.Length.Equals("00000000".Length) ? value :  value.Insert(2, "/").Insert(5, "/");            
        }

        public static string ToNumber(this string value)
        {
            return Regex.Replace(value, "[^0-9.]", "");
        }

    }
}
