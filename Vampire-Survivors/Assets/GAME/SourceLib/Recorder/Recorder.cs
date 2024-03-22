using System.Collections.Generic;
namespace VampireSurvivors.Lib.Record
{
    public class Recorder<TKey,TValue>
    {
        private Dictionary<TKey, TValue> _recordeds = null;


        public Recorder(Dictionary<TKey, TValue> a_recordeds)
        {
            _recordeds = a_recordeds;
        }


        public void Record (TKey a_key, TValue a_recordable)
        {
            _recordeds.Add(a_key, a_recordable);
        }
    }
}