using System;
using System.Collections.Generic;

namespace Essential.ServiceModel.Infrastructure
{
    internal static class ReflectionExtensions
    {
        public static IEnumerable<Type> GetTypeHierarchy(this Type type)
        {
            while (true)
            {
                var baseType = type.BaseType;
                yield return type;
                if (baseType != null)
                {
                    type = baseType;
                    continue;
                }
                break;
            }
        }
    }
}
