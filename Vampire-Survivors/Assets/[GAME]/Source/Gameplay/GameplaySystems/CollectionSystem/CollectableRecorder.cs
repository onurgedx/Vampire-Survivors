using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectableRecorder
    {

        private Dictionary<Collider, ICollectable> _collectables=null;

        
        public CollectableRecorder(Dictionary<Collider,ICollectable> a_collectables)
        {
            _collectables = a_collectables;
        }


        public void RecordCollectable(Collider a_collider , ICollectable a_collectable)
        {
            _collectables.Add(a_collider, a_collectable);
        }
       
    }
}