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


        public void Record (TKey a_collider, TValue a_collectable)
        {
            _recordeds.Add(a_collider, a_collectable);
        }
    }

}