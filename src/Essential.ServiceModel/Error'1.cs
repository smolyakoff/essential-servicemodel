using System;

namespace Essential.ServiceModel
{
    public class Error<T>  : Error
        where T : Exception
    {
        public Error(T exception) : base(exception)
        {
        }

        public T Exception
        {
            get { return (T) GetException(); }
        }
    }
}
