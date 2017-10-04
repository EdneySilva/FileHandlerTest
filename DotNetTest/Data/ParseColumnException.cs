using System;
using System.Runtime.Serialization;

namespace DotNetTest.Data
{
    [Serializable]
    internal class ParseColumnException : Exception
    {
        public ParseColumnException()
        {
        }

        public ParseColumnException(string message) : base(message)
        {
        }

        public ParseColumnException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ParseColumnException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}