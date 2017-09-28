using DotNetTest.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DotNetTest.Validators
{
    class FileExists : IValidator
    {
        public FileExists()
        {
            ErrorMessage = "Não foi possível localizar o arquivo '{0}'";
        }

        private string originalErrorMessage;
        private string errorMessage;

        public string ErrorMessage { get { return errorMessage; } set { errorMessage = originalErrorMessage = value; } }

        public ExecutionOrder ExecuteWhen => ExecutionOrder.FileIsOpenning;

        public bool IsValid(IFileHandler fileHandler)
        {
            errorMessage = originalErrorMessage;
            errorMessage = string.Format(errorMessage, fileHandler.FileName);
            return File.Exists(fileHandler.FileName);
        }
    }
}
