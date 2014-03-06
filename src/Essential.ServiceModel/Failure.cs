namespace Essential.ServiceModel
{
    public class Failure : Response
    {
        private string _message;

        public Failure(string message)
        {
            _message = message;
        }

        public Failure(string messageFormat, params object[] formatParameters)
        {
            _message = string.Format(messageFormat, formatParameters);
        }

        public virtual string Message
        {
            get { return _message; }
            protected set { _message = value; }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", base.ToString(), Message);
        }
    }
}
