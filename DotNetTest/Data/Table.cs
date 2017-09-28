using DotNetTest.Extensions;
using DotNetTest.Parsers.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DotNetTest.Data
{
    public class Table
    {
        Header Header { get; set; }
        List<Row> InternalRows { get; } = new List<Row>();
        public IEnumerable<Row> Rows => InternalRows.AsReadOnly();

        public IEnumerable<Column> Columns()
        {
            return Header.Columns();
        }

        public void AddColumns(Header header)
        {
            Header = header;
        }

        public void Fill(IEnumerable<string> enumerable, params IParsingValidator[] validators)
        {
            InternalRows.Clear();
            var columns = Header.Columns();
            InternalRows.AddRange(enumerable.AsParallel().AsRowCollection(Header, validators).ToArray());
        }
    }
}