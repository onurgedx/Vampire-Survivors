using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSpawner
    {
        
        private CollectableRecorder _collectableRecorder;
        private Dictionary<System.Type, ManaFactory> _manaFactories = new Dictionary<System.Type, ManaFactory>();

        public ManaSpawner(CollectableRecorder a_collectableRecorder)
        {
        }


        public void Spawn()
        {
            if (_manaFactories.TryGetValue(ManaType(), out ManaFactory factory))
            {            
                (Mana mana , GameObject manaGameobject) = factory.Create(SpawnPosition());
                Collider collider = manaGameobject.GetComponent<Collider>();
                _collectableRecorder.RecordCollectable(collider, mana );
            }
        }

        private System.Type ManaType()
        {
            return typeof(SmallMana);

        }

        private Vector3 SpawnPosition()
        {
            return Vector3.one;
        }


    }
}