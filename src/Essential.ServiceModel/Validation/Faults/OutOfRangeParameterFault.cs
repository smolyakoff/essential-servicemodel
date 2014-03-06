using Essential.ServiceModel.Validation.Resources;

namespace Essential.ServiceModel.Validation.Faults
{
    [ValidationCode("OUT_OF_RANGE")]
    public class OutOfRangeParameterFault : ParameterFault
    {
        public OutOfRangeParameterFault(string name, string message) : base(name, message)
        {
        }

        public OutOfRangeParameterFault(string name) : base(name)
        {
        }

        protected override string DefaultMessage
        {
            get { return string.Format(Messages.OutOfRange, Name); }
        }
    }
}
