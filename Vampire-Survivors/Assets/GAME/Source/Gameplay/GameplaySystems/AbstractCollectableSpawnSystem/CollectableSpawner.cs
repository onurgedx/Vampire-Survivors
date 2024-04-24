using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems
{
    public abstract class CollectableSpawner
    {
        protected IRecorder<GameObject,Collectable> _collectableRecorder = null;
        protected Dictionary<System.Type, CollectableFactory> _factories = new Dictionary<System.Type, CollectableFactory>();


        protected CollectableSpawner(IRecorder<GameObject, Collectable> a_collectableRecorder, Dictionary<Type, CollectableFactory> a_factories)
        {            
            _collectableRecorder = a_collectableRecorder;
            _factories = a_factories;
        }
        
        
        public Collectable Spawn(Type  type = null)
        {
            if (type ==null)
            {
                type = Type();
            }

            if (_factories.TryGetValue(type, out CollectableFactory factory))
            {
                (Collectable collectable, GameObject gameobjectCollectable) = factory.Create(SpawnPosition());
                
                _collectableRecorder.Record(gameobjectCollectable, collectable);
                return collectable;
            }
            return null;
        }


        protected abstract System.Type Type();


        protected abstract Vector3 SpawnPosition();
    }
}