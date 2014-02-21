namespace Essential.ServiceModel.Infrastructure
{
    public interface IResponseHandler<TResult>
    {
        IResponseMap<TResponse, TResult> On<TResponse>() where TResponse : Response;

        TResult Execute();
    }
}
