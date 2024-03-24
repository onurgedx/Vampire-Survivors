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

        private List<Chest> _activeChests = new List<Chest>();


        public IProperty<float> CollectableRange => _collectRange;
        private Property<float> _collectRange { get; set; }

        private Transform _chestParentTransform;
        private IProperty<Transform> _playerTransform;

        private int _currentChestCount = 0;
        private int _maxChestCountSameTimeAtArena = 3;
        private float _chestSpawnDelayDuration = 4;
        private float _spawnTimer = 0;


        public ChestSystem(CollectionSystem a_collectionSystem, IProperty<Transform> a_playerTransform, LayerMask a_chestLayer, Transform a_chestParentTransform)
        {
            _playerTransform = a_playerTransform;
            _chestParentTransform = a_chestParentTransform;
            _collectableRecorder = a_collectionSystem.CollectableRecorder;
            _collectRange = new Property<float>(1);
            _collector = new Collector(a_playerTransform, _collectRange, a_chestLayer);
            _collector.OnCollect += OnAChestCollected;
            a_collectionSystem.CollectionController.AddCollector(_collector);
            CreateSpawner();
        }


        public override void Update()
        {
            base.Update();
            ProcessChestCreating();
        }


        private void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> chestBig = Addressables.LoadAssetAsync<GameObject>(Keys.ChestBig);
            AsyncOperationHandle<GameObject> chestMedium = Addressables.LoadAssetAsync<GameObject>(Keys.ChestMedium);
            AsyncOperationHandle<GameObject> chestSmall = Addressables.LoadAssetAsync<GameObject>(Keys.ChestSmall);
            chestMedium.Completed += (_) =>
            {
                Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
                {
                    {typeof(SmallChest) , new SmallChestFactory(chestSmall.Result,_chestParentTransform) },
                    {typeof(MediumChest) , new MediumChestFactory(chestMedium.Result,_chestParentTransform)},
                    {typeof(BigChest) , new BigChestFactory(chestBig.Result,_chestParentTransform)}
                };
                _spawner = new ChestSpawner(_collectableRecorder, factories, _playerTransform);
            };
        }


        private void ProcessChestCreating()
        {
            if (_currentChestCount >= _maxChestCountSameTimeAtArena)
            {
                return;
            }
            _spawnTimer += Time.deltaTime;
            if (_spawnTimer > _chestSpawnDelayDuration)
            {
                _spawnTimer = 0;
                Chest chest = _spawner.Spawn() as Chest;
                if (chest != null)
                {
                    OnAChestCreated(chest);
                }
            }
        }


        private void OnAChestCollected(Collectable a_collectable)
        {
            if (a_collectable is Chest chest)
            {
                OpenChest(chest);
                _activeChests.Remove(chest);
                _currentChestCount--;
            }
        }


        private void OnAChestCreated(Chest a_chest)
        {
            _activeChests.Add(a_chest);
            _currentChestCount++;
        }

        private void OpenChest(Chest a_chest)
        {
            Debug.Log("A chest Opened");
            if(a_chest is BigChest bigchest)
            {                
                // do something
            }
            else if (a_chest is MediumChest mediumchest)
            {
                // do something
            }
            else if ( a_chest is SmallChest smallChest)
            {
                // do something
            }

        }

    }
}