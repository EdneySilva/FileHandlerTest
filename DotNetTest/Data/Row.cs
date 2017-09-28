using System.Collections.Generic;
using System.Linq;

namespace DotNetTest.Data
{
    public struct Row
    {
        public object[] Values { get; set; }
        public Header Header { get; }
        
        public Row(Header header)
        {            
            Header = header;
            Values = new object[header.Count()];
        }

        public object this[string column]
        {
            get { return Values[Header[column].Index - 1]; }
            set { Values[Header[column].Index - 1] = value; }
        }

        public void AddValue(string columnName, object value)
        {
            Values[Header[columnName].Index - 1] = value;
        }
    }
}