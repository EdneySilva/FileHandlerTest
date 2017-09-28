using DotNetTest.Parsers.Validators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers
{
    interface IParser
    {
        DataTable AsDataTable();
        void CopyTo(StringBuilder text, DataTable newValues);
        IParser Run(IEnumerable<string> lines, params IParsingValidator[] validators);
    }

    interface IParser<T> : IParser
    {
    }
}
