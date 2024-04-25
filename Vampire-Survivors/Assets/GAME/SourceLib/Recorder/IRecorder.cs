namespace VampireSurvivors.Lib.Record
{
    /// <summary>
    /// Recorder Interface which has only record ability
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public interface IRecorder<TKey, TValue>
    {
        public void Record(TKey a_key, TValue a_recordable);
    }
}