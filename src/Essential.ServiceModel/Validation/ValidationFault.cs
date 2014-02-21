using System;
using System.Reflection;
using Essential.ServiceModel.Validation.Resources;

namespace Essential.ServiceModel.Validation
{
    [ValidationCode("FAULT")]
    public abstract class ValidationFault : IEquatable<ValidationFault>
    {
        private string _id;

        private readonly string _message;

        public static InvalidFailureBuilder For(string name)
        {
            return new InvalidFailureBuilder(name);
        }

        protected ValidationFault() : this(null)
        {
        }

        protected ValidationFault(string message)
        {
            _message = message;
        }

        public string Id
        {
            get { return GetId(); }
        }

        public virtual string Message
        {
            get { return _message ?? DefaultMessage; }
        }

        public bool Equals(ValidationFault other)
        {
            return other != null && other.Id.Equals(this.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var code = obj as ValidationFault;
            return code != null && Equals(code);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("[{0}]: {1}", Id, Message);
        }

        protected virtual string DefaultMessage
        {
            get { return Messages.Fault; }
        }

        private string GetId()
        {
            if (!string.IsNullOrEmpty(_id))
            {
                return _id;
            }
            var type = GetType();
            var attribute = type.GetCustomAttribute<ValidationCodeAttribute>();
            _id = attribute == null ? typeof(ValidationFault).GetCustomAttribute<ValidationCodeAttribute>().Code : attribute.Code;
            return _id;
        }
    }
}
