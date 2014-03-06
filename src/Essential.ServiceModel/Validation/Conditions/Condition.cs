namespace Essential.ServiceModel.Validation.Conditions
{
    public class Condition<T>
    {
        internal Condition(T value)
        {
            Value = value;
        }
 
        public T Value { private set; get; }
    }
}
