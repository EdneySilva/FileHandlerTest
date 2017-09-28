using DotNetTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers.Validators
{
    public interface IParsingValidator
    {
        ParseResult IsValid(Row row);
    }
}
