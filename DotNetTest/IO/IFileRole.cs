using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetTest.IO
{
    public interface IFileRole
    {
        IFileRole Check();
        Try<Exception, bool> Result();
    }
}
