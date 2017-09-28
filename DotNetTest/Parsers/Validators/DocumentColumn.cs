using DotNetTest.Data;
using DotNetTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers.Validators
{
    class DocumentColumn : IParsingValidator
    {
        public DocumentColumn(params string[] columns)
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
            Columns.Where(a => !a.IsNumber()).AsParallel().Select(a => {
                row[a] = row[a]?.ToString().ToNumber();
                return a;
            }).ForAll(a =>
            {
                row[a] = row[a]?.ToString().ToCpf();
            });
            return ParseResult.Success;
        }
    }
}
