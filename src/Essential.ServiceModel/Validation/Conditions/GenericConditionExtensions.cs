using System;

namespace Essential.ServiceModel.Validation.Conditions
{
    public static class GenericConditionExtensions
    {
        public static Func<bool> IsNull<T>(this Condition<T> condition) 
            where T : class
        {
            return () =>  condition.Value != null;
        }
    }
}
