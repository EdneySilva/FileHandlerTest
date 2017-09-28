using System;
using System.Runtime.Serialization;

namespace DotNetTest.Data
{
    [Serializable]
    internal class ColumnNotFound : Exception
    {
        public ColumnNotFound()
        {
        }

        public ColumnNotFound(string message) : base(message)
        {
        }

        public ColumnNotFound(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ColumnNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}