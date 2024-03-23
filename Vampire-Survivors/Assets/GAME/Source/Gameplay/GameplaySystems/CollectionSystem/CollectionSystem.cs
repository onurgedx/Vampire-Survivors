using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionSystem : VSSystem
    {
        private Dictionary<GameObject, ICollectable> _collectables = new Dictionary<GameObject, ICollectable>();
        public CollectableRecorder CollectableRecorder { get; private set; }
        public CollectionController CollectionController { get; private set; }


        public CollectionSystem( )
        {
            CollectableRecorder = new CollectableRecorder(_collectables);
            CollectionController = new CollectionController(_collectables);
        }


        public override void Update()
        {
            base.Update();
            CollectionController.Update();
        }
                
    }
}