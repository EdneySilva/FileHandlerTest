using DotNetTest.Data;
using DotNetTest.Parsers.Validators;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DotNetTest.Extensions;

namespace DotNetTest.Parsers
{
    class DefaultParser : IParser<Table>
    {
        DataTable CachedDataTable { get; set; } = new DataTable();
        Table Table { get; } = new Table();

        public DataTable AsDataTable()
        {
            if (CachedDataTable.Rows.Count.Equals(0))
            {
                CachedDataTable.Columns.AddRange(Table.Columns()
                    .Select(s => new DataColumn(s.Name, typeof(object))).ToArray());
                foreach (var rowItem in Table.Rows.Select(s =>
                {
                    var row = CachedDataTable.NewRow();
                    foreach (var column in s.Header.Columns())
                    {
                        row[column.Name] = s.Values[column.Index - 1];
                    }
                    return row;
                }).ToArray())
                    CachedDataTable.Rows.Add(rowItem);
            }

            return CachedDataTable;
        }

        public void CopyTo(StringBuilder text, DataTable newValues)
        {
            var columns = this.WriteHeader(text, newValues.Columns);
            foreach (var item in newValues.Rows.Cast<DataRow>())
            {
                foreach (var column in columns)
                {
                    text.Append(item[column.Name]?.ToString().RemoveFormats().PadRight(column.EndIndex));
                }
                text.AppendLine();
            }
        }

        public IParser Run(IEnumerable<string> lines, params IParsingValidator[] validators)
        {
            if (Table.Rows.Any())
                return this;
            
            if (!lines?.Any() ?? true) 
                return this;
            var headerLine = lines.First();
            Header header = new Header(headerLine);
            header.ConfigureColumn("DOCUMENTO", 0, 12)
                .ConfigureColumn("DTNASC", 0, 9)
                .ConfigureColumn("NOME", 0, 36)
                .ConfigureColumn("ENDERECO", 0, 29)
                .ConfigureColumn("NUM", 0, 7)
                .ConfigureColumn("COMP", 0, 13)
                .ConfigureColumn("BAIRRO", 0, 19)
                .ConfigureColumn("CIDADE", 0, 19)
                .ConfigureColumn("CEP", 0, 8)
                .ConfigureColumn("PAI", 0, 37)
                .ConfigureColumn("MAE", 0, 36);
            Table.AddColumns(header);
            if (lines.Count().Equals(1))
                return this;
            Table.Fill(lines.Skip(1), validators);
            return this;
        }

        private IEnumerable<Column> WriteHeader(StringBuilder text, DataColumnCollection columns)
        {
            var tableColumns = Table.Columns().Where(w => columns.Cast<DataColumn>().Any(a => a.ColumnName.Equals(w.Name))).ToArray();
            foreach (var item in tableColumns)
            {                
                text.Append(item.Name.PadRight(item.EndIndex));
            }
            text.AppendLine();
            return tableColumns;
        }
    }
}
