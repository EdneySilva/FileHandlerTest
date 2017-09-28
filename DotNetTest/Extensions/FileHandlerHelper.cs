using DotNetTest.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.Extensions
{
    static class FileHandlerHelper
    {
        public static IEnumerable<string> FileIsValidToOpen(this IEnumerable<IValidator> validators)
        {
            validators.Where(w => w.ExecuteWhen == ExecutionOrder.FileIsOpenning);
            return null;
        }
    }
}
