using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionController
    {

        private Dictionary<GameObject, ICollectable> _collectables = new Dictionary<GameObject, ICollectable>();
        private List<Collector> _collectors = new List<Collector>();


        public CollectionController(Dictionary<GameObject, ICollectable> a_collectables)
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
                    if (_collectables.TryGetValue(collider.gameObject, out ICollectable collectable))
                    {
                        collector.Collect(collectable);
                        _collectables.Remove(collider.gameObject);
                    }
                }
            }
        }
    }
}