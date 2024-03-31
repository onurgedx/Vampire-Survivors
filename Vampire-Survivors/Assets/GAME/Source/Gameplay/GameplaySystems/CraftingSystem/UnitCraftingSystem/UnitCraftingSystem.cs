using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems
{
    public class UnitCraftingSystem : VSSystem
    {

        private Dictionary<string, GameObject> _unitPrefabs = new Dictionary<string, GameObject>();
        private UnitFactory _unitFactory;

        public IProperty<Transform> PlayerTransform => _playerTransform;
        private Property<Transform> _playerTransform { get; set; }

        public Action _playerLoad;
        private AIControlSystem _aiControlSystem;

        private DamageableRecorder _damageableRecorder;

        private float _timeCounter = 0;
        private float _enemyCreateDelayDuration = 2;

        public UnitCraftingSystem(PlayerControlSystem a_playerControlSystem, AIControlSystem a_aiControlSystem, DamageableRecorder a_damageableRecorder)
        {
            _damageableRecorder = a_damageableRecorder;
            _aiControlSystem = a_aiControlSystem;
            _unitFactory = new UnitFactory();
            _playerTransform = new Property<Transform>(null);
            _playerLoad = () => CraftPlayer(a_playerControlSystem);
            LoadUnitsPrefabs();
        }

        public override void Update()
        {
            base.Update();
            if (IsTimeToCreateEnemy())
            {
                CreateEnemy();
            }
        }

        public void CraftPlayer(PlayerControlSystem a_playerControlSystem)
        {
            if (_unitPrefabs.TryGetValue(Keys.PlayerDefault, out GameObject playerGameobject))
            {
                (PlayerUnit unit, UnitBehaviour playerUnitBehavior) = _unitFactory.CreatePlayerUnit(a_playerControlSystem, playerGameobject);
                _playerTransform.SetValue(playerUnitBehavior.transform);
            }
        }


        public void CreateEnemy()
        {
            if (_unitPrefabs.TryGetValue(Keys.EnemyDefault, out GameObject enemyGo))
            {
                (EnemyUnit unit, UnitBehaviour behavior) = _unitFactory.CreateEnemyUnit(_aiControlSystem.EnemyMovementControl, enemyGo, null);
                _damageableRecorder.Record(behavior.gameObject , unit);
            }
        }


        private void LoadUnitsPrefabs()
        {
            foreach (string unitKey in Keys.Units)
            {
                AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(unitKey);
                asyncOperationHandle.Completed += (asyncOperationHandle) =>
                {
                    _unitPrefabs.Add(unitKey, asyncOperationHandle.Result);
                    if (unitKey == Keys.PlayerDefault)
                    {
                        _playerLoad?.Invoke();
                    }
                };
            }
        }


        private bool IsTimeToCreateEnemy()
        {
            _timeCounter += Time.deltaTime;
            bool canCreate = _timeCounter >= _enemyCreateDelayDuration;
            if (canCreate)
            {
                _timeCounter = 0;
            }
            return canCreate;

        }
    }
}