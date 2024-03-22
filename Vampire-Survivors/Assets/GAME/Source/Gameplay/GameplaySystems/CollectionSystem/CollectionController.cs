using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionController
    {

        private Dictionary<Collider, ICollectable> _collectables = new Dictionary<Collider, ICollectable>();
        private List<Collector> _collectors = new List<Collector>();


        public CollectionController(Dictionary<Collider, ICollectable> a_collectables)
        {
            _collectables = a_collectables;
        }


        public void AddCollector(Collector a_collector)
        {
            _collectors.Add(a_collector);
        }


        public void Update()
        {
            foreach (Collector collector in _collectors)
            {
                Collider[] colliders = collector.Collect();
                foreach (Collider collider in colliders)
                {
                    if (_collectables.TryGetValue(collider, out ICollectable collectable))
                    {
                        collectable.Collect();
                        _collectables.Remove(collider);
                    }
                }
            }
        }
    }
}