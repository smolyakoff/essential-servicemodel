using System;

namespace Essential.ServiceModel
{
    public abstract class Response
    {
        private readonly DateTime _timestamp;

        protected Response()
        {
            _timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
        }

        public override string ToString()
        {
            const string format = "{0} at [{1}]";
            return string.Format(format, this is Success ? "Success" : "Failure", Timestamp);
        }
    }
}
