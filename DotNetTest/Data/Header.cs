using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Data
{
    public struct Header : IEnumerable<Column>
    {
        string HeaderLine { get; set; }
        Dictionary<string, Column> Container { get; }

        public Column this[string name]
        {
            get {
                if(!Container.ContainsKey(name))
                    throw new ColumnNotFound($"A coluna {name} não foi encontrada no arquivo");
                return Container[name];
            }
        }

        public Header(string headerLine)
        {
            Container = new Dictionary<string, Column>();
            HeaderLine = headerLine;
        }

        public Header ConfigureColumn(string name, short startIndex, short endIndex)
        {
            var columnString = HeaderLine.Substring(startIndex, endIndex);
            if (!name.Contains(columnString.Trim()))
                throw new ColumnNotFound($"A coluna {name} não foi encontrada no arquivo");
            HeaderLine = HeaderLine.Substring(endIndex);
            Column column = new Column(name);
            column.StartIndex = 0;
            column.EndIndex = endIndex;
            column.Index = Container.Count + 1;
            Container.Add(name, column);
            return this;
        }

        public IEnumerable<Column> Columns()
        {
            return Container.Values;
        }

        public IEnumerator<Column> GetEnumerator()
        {
            return this.Columns().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Columns().GetEnumerator();
        }
    }
}
