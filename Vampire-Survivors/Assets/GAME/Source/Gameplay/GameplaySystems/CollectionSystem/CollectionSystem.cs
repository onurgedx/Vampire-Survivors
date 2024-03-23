using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectionSystem : VSSystem
    {
        private Dictionary<GameObject, Collectable> _collectables = new Dictionary<GameObject, Collectable>();
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