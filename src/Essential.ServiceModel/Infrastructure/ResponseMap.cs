using System;

namespace Essential.ServiceModel.Infrastructure
{
    public abstract class ResponseMap<TResult>
    {
        internal abstract Action<dynamic> Do();

        internal abstract Func<dynamic, TResult> React();
    }
}
