using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Vectors;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSpawner : CollectableSpawner
    { 

        private IProperty<Vector3> _originTransform;
        private float _maxSpawnDistance = 25;
        private float _minSpawnDistance = 4;


        public ManaSpawner(IRecorder<GameObject, Collectable> a_collectableRecorder,
                           Dictionary<Type, CollectableFactory> a_manaFactories,
                           IProperty<Vector3> a_originPosition) : base(a_collectableRecorder, a_manaFactories)
        {
            _originTransform = a_originPosition;
        }

        protected override Vector3 SpawnPosition()
        {            
                      
            return VSVectors.RandomPosition(_originTransform.Value, _minSpawnDistance, _maxSpawnDistance);
        }

        protected override Type Type()
        {
            return typeof(MediumMana);
        }
    }
}