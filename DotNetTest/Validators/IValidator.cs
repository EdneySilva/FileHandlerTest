using DotNetTest.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Validators
{
    interface IValidator
    {
        ExecutionOrder ExecuteWhen { get; }
        string ErrorMessage { get; set; }
        bool IsValid(IFileHandler fileHandler);
    }
}
