using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
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


        public ChestSpawner(IRecorder<GameObject, Collectable> a_collectableRecorder,
                            Dictionary<Type, CollectableFactory> a_factories,
                            IProperty<Vector3> a_originTransform) : base(a_collectableRecorder, a_factories)
        {
            _originTransform = a_originTransform;
        }


        protected override Vector3 SpawnPosition()
        {
            return VSVectors.RandomPosition(_originTransform.Value, _minSpawnDistance, _maxSpawnDistance);
        }


        protected override Type Type()
        {
            return typeof(MediumChest);            
        }
    }
}