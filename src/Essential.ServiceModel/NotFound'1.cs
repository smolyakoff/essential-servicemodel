using System;
using Essential.ServiceModel.Resources;

namespace Essential.ServiceModel
{
    public class NotFound<T> : NotFound
    {
        public NotFound(string message) : base(message)
        {
        }

        public NotFound(object id) : base(Messages.NotFoundFailureOfT, typeof(T).Name, id)
        {
        }

        public Type ObjectType
        {
            get { return typeof (T); }
        }
    }
}
