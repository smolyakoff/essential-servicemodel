using System;

namespace Essential.ServiceModel.Validation.Conditions
{
    public static class StringConditionExtensions
    {
        public static Func<bool> Empty(this Condition<string> condition)
        {
            return () => string.IsNullOrEmpty(condition.Value);
        }

        public static LengthConditions Length(this Condition<string> condition)
        {
            return new LengthConditions(condition.Value);
        }

        public class LengthConditions
        {
            private readonly string _value;

            internal LengthConditions(string value)
            {
                _value = value;
            }

            public Func<bool> LessThen(int length)
            {
                if (_value == null)
                {
                    return () => false;
                }
                return () => _value.Length < length;
            } 
        }
    }
}
