using System;

namespace Essential.ServiceModel.Infrastructure
{
    internal class ResponseMap<TResponse, TResult> : ResponseMap<TResult>, IResponseMap<TResponse, TResult> where TResponse : Response
    {
        private readonly ResponseHandler<TResult> _handler;

        private Action<TResponse> _doAction;

        private Func<TResponse, TResult> _reactAction;  

        internal ResponseMap(ResponseHandler<TResult> handler)
        {
            _handler = handler;
        }

        public IResponseMap<TResponse, TResult> Do(Action<TResponse> action)
        {
            if (_doAction == null)
            {
                _doAction = action;
            }
            else
            {
                _doAction += action;
            }
            return this;
        }

        public IResponseMap<TResponse, TResult> Do(Action<TResponse> action, Predicate<TResponse> predicate)
        {
            var predicateAction = new Action<TResponse>(response =>
            {
                if (predicate(response))
                {
                    action(response);
                }
            });
            Do(predicateAction);
            return this;
        }

        public IResponseMap<TResponse, TResult> DoNothing()
        {
            _doAction = null;
            return this;
        }

        public IResponseHandler<TResult> React(Func<TResponse, TResult> action)
        {
            _reactAction = action;
            return _handler;
        }

        public IResponseMap<TResponse1, TResult> On<TResponse1>() where TResponse1 : Response
        {
            return _handler.On<TResponse1>();
        }

        internal override Action<dynamic> Do()
        {
            if (_doAction == null)
            {
                return d => {};
            }
            return d => _doAction((TResponse) d);
        }

        internal override Func<dynamic, TResult> React()
        {
            if (_reactAction == null)
            {
                return null;
            }
            return d => _reactAction((TResponse) d);
        }

        
    }
}
