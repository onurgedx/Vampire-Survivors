using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class ChestSystem : VSSystem
    {

        private Collector _collector;
        private CollectableRecorder _collectableRecorder;
        private ChestSpawner _spawner;


        public IProperty<float> CollectableRange => _collectRange;
        private Property<float> _collectRange { get; set; }

        private Transform _chestParentTransform;
        private Transform _playerTransform;
        public ChestSystem(CollectionSystem a_collectionSystem, Transform a_playerTransform, LayerMask a_chestLayer, Transform a_chestParentTransform)
        {
            _playerTransform = a_playerTransform;
            _chestParentTransform = a_chestParentTransform;
            _collectableRecorder = a_collectionSystem.CollectableRecorder;
            _collectRange = new Property<float>(1);
            _collector = new Collector(a_playerTransform, _collectRange, a_chestLayer);
            a_collectionSystem.CollectionController.AddCollector(_collector);
            CreateSpawner();
        }


        private void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> chestBig = Addressables.LoadAssetAsync<GameObject>(Keys.ChestBig);
            AsyncOperationHandle<GameObject> chestMedium = Addressables.LoadAssetAsync<GameObject>(Keys.ChestMedium);
            AsyncOperationHandle<GameObject> chestSmall = Addressables.LoadAssetAsync<GameObject>(Keys.ChestSmall);
            Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
            {
                { typeof(SmallChest) ,new SmallChestFactory(chestSmall.Result,_chestParentTransform) },
                {typeof(MediumChest) ,new MediumChestFactory(chestMedium.Result,_chestParentTransform)},
                {typeof(BigChest) ,new BigChestFactory(chestBig.Result,_chestParentTransform)}
            };
            _spawner = new ChestSpawner(_collectableRecorder, factories, _playerTransform);
        }
    }
}