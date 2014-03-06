using System;
using System.Collections.Generic;

namespace Essential.ServiceModel.Infrastructure
{
    public class ResponseHandler<TResult> : IResponseHandler<TResult>
    {
        private readonly Response _response;

        private readonly IDictionary<Type, ResponseMap<TResult>> _responseMappings = new Dictionary<Type, ResponseMap<TResult>>(); 

        private readonly ResponseHandlerChainBuilder<TResult> _chainBuilder; 

        public ResponseHandler(Response response)
        {
            _response = response;
            _chainBuilder = new ResponseHandlerChainBuilder<TResult>(_responseMappings);
        }

        public ResponseHandler<TResult> OnSuccess(Func<Response, TResult> action)
        {
            var map = On<Response>();
            map.React(action);
            return this;
        }

        public ResponseHandler<TResult> OnFailure(Func<Failure, TResult> action)
        {
            var map = On<Failure>();
            map.React(action);
            return this;
        }

        public ResponseHandler<TResult> OnSuccess(Action<Response> action)
        {
            var map = On<Response>();
            map.Do(action);
            return this;
        }

        public ResponseHandler<TResult> OnFailure(Action<Failure> action)
        {
            var map = On<Failure>();
            map.Do(action);
            return this;
        }

        public IResponseMap<TResponse, TResult> On<TResponse>()
            where TResponse : Response
        {
            var responseType = typeof (TResponse);
            if (_responseMappings.ContainsKey(responseType))
            {
                return (IResponseMap<TResponse, TResult>) _responseMappings[responseType];
            }
            var map = new ResponseMap<TResponse, TResult>(this);
            _responseMappings[responseType] = map;
            return map;
        }

        public TResult Execute()
        {
            var chain = _chainBuilder.Build(_response.GetType());
            try
            {
                chain.Do(_response);
                return chain.React(_response);
            }
            catch (Exception ex)
            {
                return Fail(ex);
            }
        }

        private TResult Fail(Exception exception)
        {
            var failure = new Error(exception);
            var chain = _chainBuilder.Build(typeof (Error));
            chain.Do(_response);
            return chain.React(failure);
        }
    }
}
