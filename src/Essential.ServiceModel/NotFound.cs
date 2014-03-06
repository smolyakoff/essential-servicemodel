using Essential.ServiceModel.Resources;

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

        public NotFound(object id) : base(Messages.NotFoundFailure, id)
        {
        }
    }
}
