using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Lists;
using VampireSurvivors.Lib.Basic.Extension.Vectors;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class ChestSpawner : CollectableSpawner
    {

        private IProperty<Vector3> _originTransform;
        private float _maxSpawnDistance = 10;
        private float _minSpawnDistance = 4;
        private List<Type> _chestTypes = new List<Type>();

        public ChestSpawner(IRecorder<GameObject, Collectable> a_collectableRecorder,
                            Dictionary<Type, CollectableFactory> a_factories,
                            IProperty<Vector3> a_originTransform) : base(a_collectableRecorder, a_factories)
        {
            _originTransform = a_originTransform;
            _chestTypes.AddRange(a_factories.Keys);
        }


        protected override Vector3 SpawnPosition()
        {
            //_originTransform.Value.RandomPosition(_minSpawnDistance, _maxSpawnDistance);
            return VSVectors.RandomPosition(_originTransform.Value, _minSpawnDistance, _maxSpawnDistance);
        }


        protected override Type Type()
        {
            return _chestTypes.Random();            
        }
    }
}