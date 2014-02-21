using System;

namespace Essential.ServiceModel.Validation
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ValidationCodeAttribute : Attribute
    {
        private readonly string _code;

        public ValidationCodeAttribute(string code)
        {
            _code = code;
        }
        public string Code
        {
            get { return _code; }
        }
    }
}
