
using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems
{
    public abstract class Spawner
    {
        protected CollectableRecorder _collectableRecorder = null;
        protected Dictionary<System.Type, CollectableFactory> _manaFactories = new Dictionary<System.Type, CollectableFactory>();

        protected Spawner(CollectableRecorder a_collectableRecorder, Dictionary<Type, CollectableFactory> a_manaFactories)
        {
            _collectableRecorder = a_collectableRecorder;
            _manaFactories = a_manaFactories;
        }

        public void Spawn()
        {
            if (_manaFactories.TryGetValue(Type(), out CollectableFactory factory))
            {
                (ICollectable collectable, GameObject manaGameobject) = factory.Create(SpawnPosition());
                Collider collider = manaGameobject.GetComponent<Collider>();
                _collectableRecorder.Record(collider, collectable);
            }
        }


        protected abstract System.Type Type();

        protected abstract Vector3 SpawnPosition();

    }
}