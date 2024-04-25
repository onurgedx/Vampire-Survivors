namespace VampireSurvivors.Lib.Basic.Properties
{

    /// <summary>
    /// Property for just get value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IProperty<T>
    {
        public T Value { get; }
    }
}