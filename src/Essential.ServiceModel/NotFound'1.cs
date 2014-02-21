using System;

namespace Essential.ServiceModel
{
    public class NotFound<T> : NotFound
    {
        public NotFound(string message) : base(message)
        {
        }

        public NotFound(object id) : base("{0} with id [{1}] was not found.", typeof(T).Name, id)
        {
        }

        public Type ObjectType
        {
            get { return typeof (T); }
        }
    }
}
