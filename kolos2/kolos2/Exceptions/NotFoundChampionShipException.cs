using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace kolos2.Exceptions
{
    public class NotFoundChampionShipException : Exception
    {
        public NotFoundChampionShipException()
        {
        }

        public NotFoundChampionShipException(string message) : base(message)
        {
        }

        public NotFoundChampionShipException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotFoundChampionShipException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
