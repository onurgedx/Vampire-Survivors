namespace VampireSurvivors.Lib.Basic.Properties
{
    public class Property<T> : IProperty<T>
    {
        public T Value { get; private set; }

        public Property(T a_value)
        {
            Value = a_value;
        }
        
        public virtual void SetValue(T a_value)
        {
            Value = a_value;
        }       

    }
}