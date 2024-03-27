using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.HealSys
{
    public class HealSpawner : CollectableSpawner
    { 

        private IProperty<Vector3> _originTransform;
        private float _maxSpawnDistance = 10;
        private float _minSpawnDistance = 4;

        public HealSpawner(CollectableRecorder a_collectableRecorder,
                            Dictionary<Type, CollectableFactory> a_factories,
                            IProperty<Vector3> a_originTransform) : base(a_collectableRecorder, a_factories)
        {
            _originTransform = a_originTransform;
        }


        protected override Vector3 SpawnPosition()
        {
            float distanceX = UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
            float distanceY = UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
            float xSign = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
            float ySign = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
            Vector3 extraSpawnPosition = Vector3.right * distanceX * xSign + Vector3.up * distanceY * ySign;
            return _originTransform.Value + extraSpawnPosition;
        }


        protected override Type Type()
        {
            return typeof(Heal);
        }
    }
}