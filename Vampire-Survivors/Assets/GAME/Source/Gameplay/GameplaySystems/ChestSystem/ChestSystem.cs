using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Systems.SkillSys;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class ChestSystem : AbstractCollectableSpawnSystem<Chest>
    {

        private ISkillRequester _skillRequester;
        public ChestSystem(CollectionSystem a_collectionSystem,
                           IProperty<Vector3> a_originTransform,
                           LayerMask a_collectableLayer,
                           Transform a_collectableParentTransform,
                           ISkillRequester a_skillRequester) : base(a_collectionSystem, a_originTransform, a_collectableLayer, a_collectableParentTransform)
        {
            _collectRange.SetValue(1);
            _collectableSpawnDelayDuration = 10;
            _maxActiveCollectableCount = 3;
            _skillRequester = a_skillRequester;
        }
         

        protected override void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> chestBig = Addressables.LoadAssetAsync<GameObject>(Keys.ChestBig);
            AsyncOperationHandle<GameObject> chestMedium = Addressables.LoadAssetAsync<GameObject>(Keys.ChestMedium);
            AsyncOperationHandle<GameObject> chestSmall = Addressables.LoadAssetAsync<GameObject>(Keys.ChestSmall);
            chestMedium.Completed += (_) =>
            {
                Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
                {
                    {typeof(SmallChest) , new SmallChestFactory(chestSmall.Result,_parentTransform) },
                    {typeof(MediumChest) , new MediumChestFactory(chestMedium.Result,_parentTransform)},
                    {typeof(BigChest) , new BigChestFactory(chestBig.Result,_parentTransform)}
                };
                _spawner = new ChestSpawner(_collectableRecorder, factories, _originPosition);
            };
        }         


        protected override void OnCollected(Collectable a_collectable)
        {
            if (a_collectable is Chest chest)
            {
                _skillRequester.RequestSkill();
                _activeCollectables.Remove(chest);
                _activeCollectableCount--;
            }
        }


        protected override void OnCreated(Chest a_chest)
        {
            _activeCollectables.Add(a_chest);
            _activeCollectableCount++;
        }      
    }
}