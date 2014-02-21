using System;

namespace Essential.ServiceModel
{
    public class Response
    {
        private readonly DateTime _timestamp;

        public Response()
        {
            _timestamp = DateTime.UtcNow;
        }

        public virtual bool IsSuccess
        {
            get { return true; }
        }

        public DateTime Timestamp
        {
            get { return _timestamp; }
        }

        public override string ToString()
        {
            const string format = "{0} at [{1}]";
            return string.Format(format, IsSuccess ? "Success" : "Failure", Timestamp);
        }
    }
}
