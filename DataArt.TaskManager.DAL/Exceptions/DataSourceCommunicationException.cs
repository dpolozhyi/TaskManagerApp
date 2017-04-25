using System;
using System.Runtime.Serialization;

namespace DataArt.TaskManager.DAL.Exceptions
{
    [Serializable]
    public class DataSourceCommunicationException : Exception
    {
        public DataSourceCommunicationException()
        {

        }

        public DataSourceCommunicationException(string message) : base(message)
        {

        }

        public DataSourceCommunicationException(string message, Exception inner) : base(message, inner)
        {

        }

        protected DataSourceCommunicationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
