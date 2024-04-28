using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Record;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    /// <summary>
    ///  Controls Spawning and Collecting Manas
    /// </summary>
    public class ManaSystem : AbstractCollectableSpawnSystem<Mana>
    {
        private IExperiencer _experiencer;

        private float _createDelay = 2;

        private Dictionary<Type, Experience> _manaExperiences = new Dictionary<Type, Experience>()
        {
            {typeof(SmallMana), new Experience(3) },
            {typeof(MediumMana), new Experience(6) },
            {typeof(BigMana), new Experience(9) },

        };


        public ManaSystem(IRecorder<GameObject, Collectable> a_recorder,
                          ICollectorAdder a_collectorAdder,
                          IProperty<Vector3> a_originTransform,
                          Transform a_collectableParentTransform,
                          IExperiencer a_experiencer) : base(a_recorder, a_collectorAdder, a_originTransform, Layers.ManaLayerMask, a_collectableParentTransform)
        {
            _experiencer = a_experiencer;
            _collectRange.SetValue(1);
            _vsTimeCounter = new VSTimerCounter(_createDelay, _createDelay - 5);
            _maxActiveCollectableCount = 60;
        }


        /// <summary>
        /// Player gains experience
        /// </summary>
        /// <param name="a_collectable"></param>
        protected override void OnCollected(Collectable a_collectable)
        {
            if (a_collectable is Mana mana)
            {
                _activeCollectableCount--;
                _activeCollectables.Remove(mana);
                if (_manaExperiences.TryGetValue(mana.GetType(), out Experience exp))
                {
                    _experiencer.ExperienceGained(exp);
                }
            }
        }


        protected override void OnCreated(Mana a_mana)
        {
            _activeCollectableCount++;
            _activeCollectables.Add(a_mana);
        }


        protected override void CreateSpawner()
        {
            AsyncOperationHandle<GameObject> manaBig = Addressables.LoadAssetAsync<GameObject>(Keys.BigMana);
            manaBig.Completed += (_) =>
            {

                AsyncOperationHandle<GameObject> manaMedium = Addressables.LoadAssetAsync<GameObject>(Keys.MediumMana);
                manaMedium.Completed += (_) =>
                {

                    AsyncOperationHandle<GameObject> manaSmall = Addressables.LoadAssetAsync<GameObject>(Keys.SmallMana);
                    manaSmall.Completed += (_) =>
                    {
                        Dictionary<Type, CollectableFactory> factories = new Dictionary<Type, CollectableFactory>()
                        {
                         {typeof(SmallMana) , new SmallManaFactory(manaSmall.Result, _parentTransform) },
                         {typeof(MediumMana) , new MediumManaFactory(manaMedium.Result, _parentTransform) },
                         {typeof(BigMana) , new BigManaFactory(manaBig.Result, _parentTransform) },
                             };
                        _spawner = new ManaSpawner(_collectableRecorder, factories, _originPosition);
                    };

                };
            };
        }
    }
}