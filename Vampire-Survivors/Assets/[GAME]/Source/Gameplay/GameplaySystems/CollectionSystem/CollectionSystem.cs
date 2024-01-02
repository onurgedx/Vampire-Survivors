using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionSystem : VSSystem
    {
        private Dictionary<Collider, ICollectable> _collectables = new Dictionary<Collider, ICollectable>();
        public CollectableRecorder CollectableRecorder { get; private set; }
        private CollectionController _collectionController;


        public CollectionSystem(IEnumerable<Collector> a_collectors)
        {
            CollectableRecorder = new CollectableRecorder(_collectables);
            _collectionController = new CollectionController(_collectables, a_collectors);
        }


        public override void Update()
        {
            base.Update();
            _collectionController.Update();
        }
                
    }
}