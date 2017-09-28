using DotNetTest.Data;
using DotNetTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers.Validators
{
    class SimpleLowerTextColumn : IParsingValidator
    {
        public SimpleLowerTextColumn(string[] columns)
        {
            ErrorMessage = "As colunas abaixo devem ser datas válidas \n: {0}";
            Columns = columns;
        }

        private string originalErrorMessage;
        private string errorMessage;
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = originalErrorMessage = value; } }
        public string[] Columns { get; }

        public ParseResult IsValid(Row row)
        {
            System.Threading.Tasks.Parallel.ForEach(Columns, (a) =>
            {
                row[a] = row[a]?.ToString().Trim().ToSimpleLowerText();
            });
            return ParseResult.Success;
        }
    }
}
