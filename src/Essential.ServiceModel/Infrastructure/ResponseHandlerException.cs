using System;

namespace Essential.ServiceModel.Infrastructure
{
    public class ResponseHandlerException : Exception
    {
        public ResponseHandlerException(Type responseType, string message, Exception innerException) : base(message, innerException)
        {
            ResponseType = responseType;
        }

        public Type ResponseType { get; private set; }
    }
}
