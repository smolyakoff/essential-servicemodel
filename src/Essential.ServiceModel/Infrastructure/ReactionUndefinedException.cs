using System;

namespace Essential.ServiceModel.Infrastructure
{
    public class ReactionUndefinedException : Exception
    {
        internal ReactionUndefinedException(Type responseType)
        {
            ResponseType = responseType;
        }

        public Type ResponseType { get; private set; }

        public override string Message
        {
            get { return string.Format("Reaction is not defined for [{0}] response.", ResponseType.Name); }
        }
    }
}
