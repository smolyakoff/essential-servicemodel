using System;

namespace Essential.ServiceModel.Infrastructure
{
    public interface IResponseMap<out TResponse, TResult> : IResponseHandler<TResult> 
        where TResponse : Response
    {
        IResponseMap<TResponse, TResult> Do(Action<TResponse> action);

        IResponseMap<TResponse, TResult> Do(Action<TResponse> action, Predicate<TResponse> predicate);

        IResponseHandler<TResult> React(Func<TResponse, TResult> action);
    }
}
