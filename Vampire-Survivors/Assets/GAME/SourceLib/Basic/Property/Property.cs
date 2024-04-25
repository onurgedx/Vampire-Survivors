namespace VampireSurvivors.Lib.Basic.Properties
{

    /// <summary>
    /// Property for set and get value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Property<T> : IProperty<T>
    {
        public T Value { get; private set; }

        public Property(T a_value)
        {
            Value = a_value;
        }
        

        /// <summary>
        /// Changes Value
        /// </summary>
        /// <param name="a_value"></param>
        public virtual void SetValue(T a_value)
        {
            Value = a_value;
        }       

    }
}