namespace VampireSurvivors.Lib.Record
{
    public interface IRecorder<TKey, TValue>
    {
        public void Record(TKey a_key, TValue a_recordable);
    }
}