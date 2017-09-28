using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTest.IO
{
    public interface IFileHandler
    {
        string FileName { get; }

        string OutputDirectory { get; }

        Try<Exception, IFileHandler> Open(string fileName);

        DataTable Read();

        Task<DataTable> ReadAsync();

        Task<Try<Exception, bool>> WriteAllDataAsync(string path, Task<DataTable> dataSourceAsync);
    }
}
