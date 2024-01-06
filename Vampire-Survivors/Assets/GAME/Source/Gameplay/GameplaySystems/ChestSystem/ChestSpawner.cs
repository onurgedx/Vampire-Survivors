using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class ChestSpawner : Spawner
    {
        public ChestSpawner(CollectableRecorder a_collectableRecorder, Dictionary<Type, CollectableFactory> a_manaFactories) : base(a_collectableRecorder, a_manaFactories)
        {
        }

        protected override Vector3 SpawnPosition()
        {
            throw new NotImplementedException();
        }

        protected override Type Type()
        {
            throw new NotImplementedException();
        }
    }
}