using DotNetTest.Extensions;
using DotNetTest.Parsers;
using DotNetTest.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using DotNetTest.Parsers.Validators;
using System.Threading.Tasks;

namespace DotNetTest.IO
{
    public class FileHandler : IFileHandler
    {

        SettingCollection Settings { get; set; }
        public string FileName { get; private set; }
        public string OutputDirectory { get; private set; }
        IParser Parser { get; set; }
        IEnumerable<string> Lines { get; set; }

        public FileHandler(SettingCollection settings)
        {
            Settings = settings;
        }

        public Try<Exception, IFileHandler> Open(string fileName)
        {
            return TryHelper.Try((IFileHandler)this, (ctx) =>
            {
                var validators = Settings.Get<IEnumerable<IValidator>>();
                this.Parser = Settings.Get<IParser>();
                this.FileName = fileName;
                Assert(ExecutionOrder.FileIsOpenning, validators);
                Lines = File.ReadAllLines(fileName, Encoding.Default);
                return ctx;
            });
        }

        private void Assert(ExecutionOrder when, IEnumerable<IValidator> validators)
        {
            var erros = validators.Where(w => w.ExecuteWhen == when)
                .Where(w => !w.IsValid(this))
                .Select(s => s.ErrorMessage)
                .ToArray();
            if (!erros.Any())
                return;
            throw new InvalidOperationException(erros.Aggregate((seed, value) => seed += "\n" + value));
        }

        public Try<Exception, DataTable> Read()
        {
            return TryHelper.Try(this, (ctx) =>
            {
                throw new Exception("Teste");
                var validators = Settings.Get<IEnumerable<IParsingValidator>>().ToArray();
                return Parser.Run(Lines, validators).AsDataTable();
            });
        }

        public Task<Try<Exception, DataTable>> ReadAsync()
        {
            Task<Try<Exception, DataTable>> task = new Task<Try<Exception, DataTable>>(() =>
            {
                return this.Read();
            });
            task.Start();
            return task;
        }

        public Task<Try<Exception, bool>> WriteAllDataAsync(string path, Task<DataTable> dataSourceAsync)
        {
            OutputDirectory = path;
            var task = new Task<Try<Exception, bool>>(() =>
            {
                return TryHelper.Try(this, (ctx) =>
                {
                    dataSourceAsync.Wait();
                    var datasource = dataSourceAsync.Result;
                    if (datasource.Rows.Count == 0)
                        return false;
                    var validators = Settings.Get<IEnumerable<IValidator>>();
                    Assert(ExecutionOrder.FileIsWritting, validators);
                    StringBuilder text = new StringBuilder();
                    Parser.CopyTo(text, datasource);
                    File.WriteAllText(path, text.ToString());
                    OutputDirectory = null;
                    return true;
                });
            });
            task.Start();
            return task;
        }

    }
}