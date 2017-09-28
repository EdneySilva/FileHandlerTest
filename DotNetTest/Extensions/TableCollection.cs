using DotNetTest.Data;
using DotNetTest.Parsers.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Extensions
{
    public static class TableCollection
    {
        public static IEnumerable<Row> AsRowCollection(this IEnumerable<string> collection, Header header, params IParsingValidator[] validators)
        {
            var columns = header.Columns();
            return collection
                .Select(s =>
                {
                    var @string = s;
                    Row newRow = new Row(header);
                    foreach (var column in columns)
                    {
                        var value = @string.Substring(column.StartIndex, column.EndIndex);
                        @string = @string.Substring(column.EndIndex);
                        newRow.AddValue(column.Name, value);
                    }
                    return newRow;
                }).Where(w => validators.All(a => a.IsValid(w) == ParseResult.Success));
        }
    }
}
