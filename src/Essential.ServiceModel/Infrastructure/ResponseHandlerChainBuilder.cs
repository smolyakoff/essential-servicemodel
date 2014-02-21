using System;
using System.Collections.Generic;
using System.Linq;

namespace Essential.ServiceModel.Infrastructure
{
    internal class ResponseHandlerChainBuilder<TResult>
    {
        private readonly IDictionary<Type, ResponseMap<TResult>> _mappings; 

        public ResponseHandlerChainBuilder(IDictionary<Type, ResponseMap<TResult>> mappings)
        {
            _mappings = mappings;
        }

        public ResponseHandlerChain<TResult> Build(Type responseType)
        {
            var typeHierarchy = responseType.GetTypeHierarchy().Concat(responseType.GetInterfaces()).ToList();
            var doAction = _mappings.Where(x => typeHierarchy.Any(t => x.Key == t))
                .Select(x => x.Value)
                .Aggregate(new Action<dynamic>(r => { }), (acc, a) => acc + a.Do());
            var reactAction = _mappings.Where(x => typeHierarchy.Any(t => x.Key == t))
                .Select(x => x.Value.React())
                .FirstOrDefault(x => x != null);
            if (reactAction == null)
            {
                
            }
            return new ResponseHandlerChain<TResult>(doAction, reactAction);
        }
    }
}
