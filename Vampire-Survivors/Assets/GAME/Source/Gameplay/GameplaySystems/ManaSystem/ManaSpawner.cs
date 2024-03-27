using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSpawner : CollectableSpawner
    { 

        private IProperty<Vector3> _originTransform;
        private float _maxSpawnDistance = 25;
        private float _minSpawnDistance = 4;


        public ManaSpawner(CollectableRecorder a_collectableRecorder,
                           Dictionary<Type, CollectableFactory> a_manaFactories,
                           IProperty<Vector3> a_originPosition) : base(a_collectableRecorder, a_manaFactories)
        {
            _originTransform = a_originPosition;
        }

        protected override Vector3 SpawnPosition()
        {            
            float distanceX = UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
            float distanceY = UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
            float xSign= UnityEngine.Random.Range(0, 2)==0 ? 1:-1;
            float ySign= UnityEngine.Random.Range(0, 2)==0 ? 1:-1;
            Vector3 extraSpawnPosition = Vector3.right * distanceX* xSign + Vector3.up*distanceY* ySign;             
            return _originTransform.Value + extraSpawnPosition;
        }

        protected override Type Type()
        {
            return typeof(MediumMana);
        }
    }
}