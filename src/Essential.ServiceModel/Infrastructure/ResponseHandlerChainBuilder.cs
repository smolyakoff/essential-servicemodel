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
            var typeHierarchy = responseType.GetTypeHierarchy().ToList();
            var doAction = _mappings.Where(x => typeHierarchy.Any(t => x.Key == t))
                .Select(x => x.Value)
                .Aggregate(new Action<dynamic>(r => { }), (acc, a) => acc + a.Do());
            var reactAction = _mappings.Join(typeHierarchy, pair => pair.Key, type => type, (pair, type) => new { ResponseType = type, Reaction = pair.Value.React()})
                .Where(x => x.Reaction != null)
                .OrderBy(x => typeHierarchy.IndexOf(x.ResponseType))
                .Select(x => x.Reaction)
                .FirstOrDefault();
            reactAction = reactAction ?? (r => { throw new ReactionUndefinedException(responseType); });
            return new ResponseHandlerChain<TResult>(doAction, reactAction);
        }
    }
}
