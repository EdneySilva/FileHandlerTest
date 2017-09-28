using DotNetTest.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DotNetTest.Validators
{
    class DirectoryExists : IValidator
    {
        public DirectoryExists()
        {
            ErrorMessage = "Não foi possível localizar o caminho '{0}'";
        }

        private string originalErrorMessage;
        private string errorMessage;

        public string ErrorMessage { get { return errorMessage; } set { errorMessage = originalErrorMessage = value; } }

        public ExecutionOrder ExecuteWhen => ExecutionOrder.FileIsWritting;

        public bool IsValid(IFileHandler fileHandler)
        {
            errorMessage = originalErrorMessage;
            errorMessage = string.Format(errorMessage, fileHandler.FileName);
            return Directory.Exists(fileHandler.OutputDirectory);
        }
    }
}
