using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    /// <summary>
    /// Controls Collectors and Manages Collection Progress
    /// </summary>
    public class CollectionController: ICollectorAdder
    {

        private Dictionary<GameObject, Collectable> _collectables = new Dictionary<GameObject, Collectable>();
        private List<ICollector> _collectors = new List<ICollector>();


        public CollectionController(Dictionary<GameObject, Collectable> a_collectables)
        {
            _collectables = a_collectables;
        }


        public void AddCollector(ICollector a_collector)
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