using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Parsers.Validators
{
    [Flags]
    public enum ParseResult
    {
        Success,
        Fail,
        Throws,
        RemoveItem
    }
}
