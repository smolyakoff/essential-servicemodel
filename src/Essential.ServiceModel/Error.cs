using System;

namespace Essential.ServiceModel
{
    public class Error : Failure
    {
        private readonly Exception _exception;

        public Error(Exception exception) : base(exception.Message)
        {
            _exception = exception;
        }

        public Exception GetException()
        {
            return _exception;
        }
    }
}
