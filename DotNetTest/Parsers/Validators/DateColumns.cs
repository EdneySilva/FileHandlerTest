using System.Linq;
using DotNetTest.Data;
using DotNetTest.Extensions;

namespace DotNetTest.Parsers.Validators
{
    class DateColumn : IParsingValidator
    {
        public DateColumn(params string[] columns)
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
            if (Columns.Select(s => row[s] = row[s]?.ToString().ToDateTime()).Any(a => !a?.IsDateTime() ?? false))
                return ParseResult.RemoveItem;
            return ParseResult.Success;
        }
    }
}
