namespace Essential.ServiceModel
{
    public class Data<T> : Data
    {
        private readonly T _value;

        public Data(T value)
        {
            _value = value;
        }

        public T Value
        {
            get { return _value; }
        }

        public override object GetValue()
        {
            return _value;
        }
    }
}
