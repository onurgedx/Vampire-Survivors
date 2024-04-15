using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.HealSys
{
    public class HealSystem : AbstractCollectableSpawnSystem<Heal>
    {

        private Dictionary<Type, int> _healAmounts = new Dictionary<Type, int>()
        {
            {typeof(Heal),100 }

        };

        private IProperty<IUnitHealth> _unitHealth;
        public HealSystem(CollectionSystem a_collectionSystem,
                          IProperty<Vector3> a_originTransform,
                          LayerMask a_collectableLayer,
                          Transform a_collectableParentTransform,
                          IProperty< IUnitHealth> a_unitHealth) : base(a_collectionSystem, a_originTransform, a_collectableLayer, a_collectableParentTransform)
        {
            _unitHealth = a_unitHealth;
            _collectRange.SetValue(1);
            _collectableSpawnDelayDuration = 20;
            _maxActiveCollectableCount = 3;
        }



        protected override void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> heal = Addressables.LoadAssetAsync<GameObject>(Keys.Heal);
            heal.Completed += (_) =>
            {
                Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
                {
                    {typeof(Heal) , new HealFactory(heal.Result,_parentTransform) },
                };
                _spawner = new HealSpawner(_collectableRecorder, factories, _originPosition);
            };
        }


        protected override void OnCollected(Collectable a_collectable)
        {
            if (a_collectable is Heal heal)
            {
                heal.Collect();
                _activeCollectables.Remove(heal);
                _activeCollectableCount--;

                if (_healAmounts.TryGetValue(heal.GetType(), out int healAmount))
                {
                    _unitHealth.Value.UpdateCurrentHealth(healAmount);
                }
            }
        }


        protected override void OnCreated(Heal a_collectabe)
        {
            _activeCollectables.Add(a_collectabe);
            _activeCollectableCount++;

        }
    }
}
