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

        private static readonly Vector3[] _spawnDirections = new Vector3[] {
            Vector3.zero,
            Vector3.up,
            Vector3.down,
            Vector3.right,
            Vector3.left,
            Vector3.up+Vector3.left,
            Vector3.up + Vector3.right,
            Vector3.down +Vector3.left,
            Vector3.down +Vector3.right,
        };

        private IProperty<Transform> _originTransform;
        private float _maxSpawnDistance = 25;
        private float _minSpawnDistance = 1;


        public ManaSpawner(CollectableRecorder a_collectableRecorder,
                           Dictionary<Type, CollectableFactory> a_manaFactories,
                           IProperty<Transform> a_originTransform) : base(a_collectableRecorder, a_manaFactories)
        {
            _originTransform = a_originTransform;
        }

        protected override Vector3 SpawnPosition()
        {
            Vector3 extraSpawnPosition = _spawnDirections.Random();
            float distance = UnityEngine.Random.Range(_minSpawnDistance, _maxSpawnDistance);
            extraSpawnPosition *= distance;
            return _originTransform.Value.position + extraSpawnPosition;
        }

        protected override Type Type()
        {
            return typeof(MediumMana);
        }
    }
}