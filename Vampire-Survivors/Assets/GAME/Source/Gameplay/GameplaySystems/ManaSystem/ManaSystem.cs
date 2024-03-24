using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSystem : AbstractCollectableSpawnSystem<Mana>
    {
        public ManaSystem(CollectionSystem a_collectionSystem,
                          IProperty<Transform> a_originTransform,
                          LayerMask a_collectableLayer,
                          Transform a_collectableParentTransform) : base(a_collectionSystem, a_originTransform, a_collectableLayer, a_collectableParentTransform)
        {
            _collectRange.SetValue(1);
            _collectableSpawnDelayDuration = 3;
            _maxActiveCollectableCount = 40;
        }

          


        protected override void OnCollected(Collectable a_collectable)
        { 
            if(a_collectable is Mana mana)
            {
                _activeCollectableCount--;
                _activeCollectables.Remove(mana);
            }
        }


        protected override void OnCreated(Mana a_mana)
        {
            _activeCollectableCount++;
            _activeCollectables.Add(a_mana);
        } 
        

        protected override void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> manaBig = Addressables.LoadAssetAsync<GameObject>(Keys.SmallMana);
            AsyncOperationHandle<GameObject> manaMedium = Addressables.LoadAssetAsync<GameObject>(Keys.MediumMana);
            AsyncOperationHandle<GameObject> manaSmall = Addressables.LoadAssetAsync<GameObject>(Keys.SmallMana);
            manaMedium.Completed += (_) =>
            {
                Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
                {
                    {typeof(SmallMana) , new SmallManaFactory(manaSmall.Result, _parentTransform) },
                    {typeof(MediumMana) , new MediumManaFactory(manaMedium.Result, _parentTransform) },
                    {typeof(BigMana) , new BigManaFactory(manaBig.Result, _parentTransform) },
                };
                _spawner = new ManaSpawner(_collectableRecorder, factories, _originTransform);
            };
        }
    }
}