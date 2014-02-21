using System;

namespace Essential.ServiceModel.Infrastructure
{
    internal class ResponseHandlerChain<TResult>
    {
        private readonly Action<dynamic> _doAction;

        private readonly Func<dynamic, TResult> _reactAction; 

        internal ResponseHandlerChain(Action<dynamic> doAction, Func<dynamic, TResult> reactAction)
        {
            _doAction = doAction;
            _reactAction = reactAction;
        } 

        public void Do(Response response)
        {
            _doAction(response);
        }

        public TResult React(Response response)
        {
            return _reactAction(response);
        }
    }
}
