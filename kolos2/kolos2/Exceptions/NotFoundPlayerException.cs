using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace kolos2.Exceptions
{
    public class NotFoundPlayerException : Exception
    {
        public NotFoundPlayerException()
        {
        }

        public NotFoundPlayerException(string message) : base(message)
        {
        }

        public NotFoundPlayerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundPlayerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
