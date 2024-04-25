using System.Collections.Generic;
namespace VampireSurvivors.Lib.Record
{
    /// <summary>
    /// Recorder for a dictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class Recorder<TKey,TValue>: IRecorder<TKey, TValue>
    {
        private Dictionary<TKey, TValue> _recordeds = null;


        public Recorder(Dictionary<TKey, TValue> a_recordeds)
        {
            _recordeds = a_recordeds;
        }


        public void Record (TKey a_key, TValue a_recordable)
        {
            if(!_recordeds.TryAdd(a_key, a_recordable))
            {
                _recordeds[a_key] = a_recordable;
            }
        }
    }
}