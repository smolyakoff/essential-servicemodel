using System.Collections.Generic;
using Essential.ServiceModel.Validation.Faults;

namespace Essential.ServiceModel.Validation
{
    public class InvalidFailureBuilder
    {
        private readonly string _name;

        private readonly List<ValidationFault> _faults; 

        internal InvalidFailureBuilder(string name) : this(name, new List<ValidationFault>())
        {
        }

        internal InvalidFailureBuilder(string name, List<ValidationFault> faults)
        {
            _name = name;
            _faults = faults;
        }

        public string Name
        {
            get { return _name; }
        }

        public InvalidFailureBuilder Required(string message = null)
        {
            var fault = new RequiredParameterFault(Name, message);
            _faults.Add(fault);
            return this;
        }

        public InvalidFailureBuilder For(string name)
        {
            return new InvalidFailureBuilder(name, _faults);
        }

        public Invalid Response(string message)
        {
            return new Invalid(message, _faults.ToArray());
        }
    }
}
