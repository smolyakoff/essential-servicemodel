using Essential.ServiceModel.Validation.Resources;

namespace Essential.ServiceModel.Validation.Faults
{
    [ValidationCode("INVALID")]
    public class ParameterFault : ValidationFault
    {
        private readonly string _name;

        public ParameterFault(string name, string message) : base(message)
        {
            _name = name;
        }

        public ParameterFault(string name) : this(name, null)
        {
        }

        public string Name
        {
            get { return _name; }
        }

        protected override string DefaultMessage
        {
            get { return string.Format(Messages.Invalid, Name); }
        }
    }
}
