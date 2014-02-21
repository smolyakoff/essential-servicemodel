using System.Collections.Generic;
using Essential.ServiceModel.Validation;

namespace Essential.ServiceModel
{
    public class Invalid : Failure
    {
        private readonly ValidationFault[] _validationFaults;

        public Invalid(string message, params ValidationFault[] validationFaults) : base(message)
        {
            _validationFaults = validationFaults;
        }

        public IEnumerable<ValidationFault> Faults
        {
            get { return _validationFaults; }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
