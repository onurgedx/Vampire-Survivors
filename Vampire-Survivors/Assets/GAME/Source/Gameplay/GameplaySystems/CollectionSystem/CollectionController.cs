using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionController
    {

        private Dictionary<GameObject, Collectable> _collectables = new Dictionary<GameObject, Collectable>();
        private List<Collector> _collectors = new List<Collector>();


        public CollectionController(Dictionary<GameObject, Collectable> a_collectables)
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
                Collider2D[] colliders = collector.Collect();
                foreach (Collider2D collider in colliders)
                {
                    if (_collectables.TryGetValue(collider.gameObject, out Collectable collectable))
                    {
                        collector.Collect(collectable);
                        _collectables.Remove(collider.gameObject);
                    }
                }
            }
        }
    }
}