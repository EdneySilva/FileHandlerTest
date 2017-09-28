using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetTest.IO;
using DotNetTest.Data;
using DotNetTest.Extensions;

namespace DotNetTest.Parsers.Validators
{
    class NumericColumns : IParsingValidator
    {
        public NumericColumns(params string[] columns)
        {
            ErrorMessage = "As colunas abaixo devem ser números válidos \n: {0}";
            Columns = columns;
        }

        private string originalErrorMessage;
        private string errorMessage;
        public string ErrorMessage { get { return errorMessage; } set { errorMessage = originalErrorMessage = value; } }
        public string[] Columns { get; }

        public ParseResult IsValid(Row row)
        {
            Columns.Where(a => !a.IsNumber()).AsParallel().ForAll(a => row[a] = row[a]?.ToString().ToNumber());
            return ParseResult.Success;
        }
    }
}
