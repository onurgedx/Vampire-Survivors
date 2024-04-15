using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionSystem : VSSystem
    {
        private Dictionary<GameObject, Collectable> _collectables = new Dictionary<GameObject, Collectable>();

        public IRecorder<GameObject, Collectable> CollectableRecorder => _collectableRecorder;
        private CollectableRecorder _collectableRecorder { get;  set; }

        public ICollectorAdder CollectorAdder => _collectionController;
        private CollectionController _collectionController { get;  set; }


        public CollectionSystem( )
        {
            _collectableRecorder = new CollectableRecorder(_collectables);
            _collectionController = new CollectionController(_collectables);
        }


        public override void Update()
        {
            base.Update();
            _collectionController.Update();
        }
                
    }
}