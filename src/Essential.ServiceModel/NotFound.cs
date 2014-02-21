namespace Essential.ServiceModel
{
    public class NotFound : Failure
    {
        public NotFound(string message) : base(message)
        {
        }

        public NotFound(string format, params object[] formatParameters) : base(format, formatParameters)
        {
        }

        public NotFound(object id) : base("Object with id [{0}] was not found.", id)
        {
        }
    }
}
