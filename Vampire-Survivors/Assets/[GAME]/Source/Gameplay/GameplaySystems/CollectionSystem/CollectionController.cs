using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionController
    {

        private Dictionary<Collider, ICollectable> _collectables = new Dictionary<Collider, ICollectable>();


        private IEnumerable<Collector> _collectors { get; }

        public CollectionController(Dictionary<Collider, ICollectable> a_collectables, IEnumerable<Collector> a_collectors)
        {
            _collectables = a_collectables;
            _collectors = a_collectors;
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