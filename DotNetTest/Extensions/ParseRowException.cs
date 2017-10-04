using System;
using System.Runtime.Serialization;

namespace DotNetTest.Extensions
{
    [Serializable]
    internal class ParseRowException : Exception
    {
        public ParseRowException()
        {
        }

        public ParseRowException(string message) : base(message)
        {
        }

        public ParseRowException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParseRowException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}