using System;

namespace Essential.ServiceModel.Infrastructure
{
    public interface IResponseMap<out TResponse, TResult>
        where TResponse : Response
    {
        IResponseMap<TResponse, TResult> Do(Action<TResponse> action);

        IResponseMap<TResponse, TResult> Do(Action<TResponse> action, Predicate<TResponse> predicate);

        IResponseMap<TResponse, TResult> DoNothing();

        IResponseHandler<TResult> React(Func<TResponse, TResult> action);

        IResponseMap<TResponse1, TResult> On<TResponse1>() where TResponse1 : Response;
    }
}
