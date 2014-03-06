namespace Essential.ServiceModel.Validation.Conditions
{
    public static class ConditionExtension
    {
        public static Condition<T> Condition<T>(this T obj)
        {
            return new Condition<T>(obj);
        } 
    }
}
