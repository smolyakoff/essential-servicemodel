using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters;
using Essential.ServiceModel.Validation.Resources;

namespace Essential.ServiceModel.Validation.Faults
{
    [ValidationCode("REQUIRED")]
    public class RequiredParameterFault : ParameterFault
    {
        public RequiredParameterFault(string name, string message) : base(name, message)
        {     
        }

        public RequiredParameterFault(string name) : base(name)
        {
        }

        protected override string DefaultMessage
        {
            get { return string.Format(Messages.Required, Name); }
        }
    }
}
