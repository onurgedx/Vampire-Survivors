using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Vectors;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.Units
{
    public class EnemyUnitFactory
    {
        private float _maxEnemySpawnDistance = 25;
        private float _minEnemySpawnDistance = 10;

        private EnemyMovementControl _enemyMovementControl;
        private IDamagableRecorder _damageableRecorder;
        private DamageSourceTypeRecorder _damageSourceTypeRecorder;

        private Dictionary<GameObject, VSObjectPool<UnitBehaviour>> _enemyPools = new Dictionary<GameObject, VSObjectPool<UnitBehaviour>>();
        private UnitData _enemyUnitData = new UnitData();

        private IProperty<Vector3> _playerPosition;
        public EnemyUnitFactory(IProperty<Vector3> a_craftOriginPosition, EnemyMovementControl a_enemyMovementControl, IDamagableRecorder a_damageableRecorder, DamageSourceTypeRecorder a_damageSourceTypeRecorder)
        {
            _enemyMovementControl = a_enemyMovementControl;
            _damageableRecorder = a_damageableRecorder;
            _damageSourceTypeRecorder = a_damageSourceTypeRecorder;
            _playerPosition = a_craftOriginPosition;
        }


        public (EnemyUnit, UnitBehaviour) CreateEnemyUnit(GameObject a_unitPrefab, UnitData a_unitData)
        {
            a_unitData = _enemyUnitData;

            UnitBehaviour behaviour = CreateUnitBehavior(a_unitPrefab);
            Property<float> speed = new Property<float>(a_unitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_unitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_unitData.AttackPower);
            EnemyUnit unit = new EnemyUnit(unitHealth, speed, damageTaken, attackPower);
            behaviour.Init(unit);
            UnitMovementData unitMovement = new UnitMovementData(speed, new Property<Transform>(behaviour.transform));
            _enemyMovementControl.Add(unit, unitMovement);
            _damageableRecorder.Record(behaviour.gameObject, unit);
            _damageSourceTypeRecorder.Record(behaviour.gameObject, unit.GetType());
            unit.OnDead += () => { _enemyMovementControl.Remove(unit); };
            return (unit, behaviour);
        }


        private UnitBehaviour CreateUnitBehavior(GameObject a_unitPrefab)
        {
            if (_enemyPools.TryGetValue(a_unitPrefab, out VSObjectPool<UnitBehaviour> pool))
            {
                if (pool.TryRetrieve(out UnitBehaviour behaviour))
                {
                    behaviour.transform.position = EnemySpawnPosition();
                    behaviour.gameObject.SetActive(true);
                    return behaviour;
                }
                else
                {
                    GameObject gameobjectUnit = GameObject.Instantiate(a_unitPrefab, EnemySpawnPosition(), Quaternion.identity);
                    behaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
                    gameobjectUnit.SetActive(true);
                    pool.Add(behaviour);
                    return behaviour;
                }
            }
            else
            {
                VSObjectPool<UnitBehaviour> newPool = new VSObjectPool<UnitBehaviour>();
                _enemyPools.Add(a_unitPrefab, newPool);
                GameObject gameobjectUnit = GameObject.Instantiate(a_unitPrefab, EnemySpawnPosition(), Quaternion.identity);
                UnitBehaviour behavior = gameobjectUnit.GetComponent<UnitBehaviour>();
                gameobjectUnit.SetActive(true);
                newPool.Add(behavior);
                return behavior;
            }
        }


        private Vector3 EnemySpawnPosition()
        {
            return VSVectors.RandomPosition(_playerPosition.Value, _minEnemySpawnDistance, _maxEnemySpawnDistance);
        }

    }
}