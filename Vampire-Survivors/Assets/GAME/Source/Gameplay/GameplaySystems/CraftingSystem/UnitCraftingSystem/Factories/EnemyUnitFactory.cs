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

        private Dictionary<string, VSObjectPool<UnitBehaviour>> _enemyPools = new Dictionary<string, VSObjectPool<UnitBehaviour>>();

        public IDictionary<string, GameObject> EnemyPrefabs => _enemyPrefabs;
        private Dictionary<string, GameObject> _enemyPrefabs = new Dictionary<string, GameObject>();

        private IProperty<Vector3> _playerPosition;
        private Transform _poolTransform;
        public EnemyUnitFactory(IProperty<Vector3> a_craftOriginPosition,
                                EnemyMovementControl a_enemyMovementControl,
                                IDamagableRecorder a_damageableRecorder,
                                DamageSourceTypeRecorder a_damageSourceTypeRecorder,
                                Transform a_poolTransform)
        {
            _poolTransform = a_poolTransform;
            _enemyMovementControl = a_enemyMovementControl;
            _damageableRecorder = a_damageableRecorder;
            _damageSourceTypeRecorder = a_damageSourceTypeRecorder;
            _playerPosition = a_craftOriginPosition;
        }


        public void AddEnemyPrefab(string a_unitName, GameObject a_prefab)
        {
            _enemyPrefabs.Add(a_unitName, a_prefab);
        }


        public (EnemyUnit, UnitBehaviour) CreateEnemyUnit(UnitData a_unitData)
        {

            Property<float> speed = new Property<float>(a_unitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_unitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_unitData.AttackPower );

            UnitBehaviour behaviour = CreateUnitBehavior(a_unitData.UnitName);
            EnemyUnit unit = new EnemyUnit(unitHealth, speed, damageTaken, attackPower);             
            behaviour.Init(unit);
            UnitMovementData unitMovement = new UnitMovementData(speed, new Property<Transform>(behaviour.transform));
            _enemyMovementControl.Add(unit, unitMovement);
            _damageableRecorder.Record(behaviour.gameObject.GetHashCode(), unit);
            _damageSourceTypeRecorder.Record(behaviour.gameObject, a_unitData.GetHashCode());
            unit.OnDead += () => { _enemyMovementControl.Remove(unit); };
            return (unit, behaviour);
        }


        private UnitBehaviour CreateUnitBehavior(string a_unitName)
        {


            if (_enemyPools.TryGetValue(a_unitName, out VSObjectPool<UnitBehaviour> pool))
            {
                if (pool.TryRetrieve(out UnitBehaviour behaviour))
                {
                    behaviour.transform.position = EnemySpawnPosition();
                    behaviour.gameObject.SetActive(true);
                    return behaviour;
                }
                else
                {
                    if (_enemyPrefabs.TryGetValue(a_unitName, out GameObject unitPrefab))
                    {

                        GameObject gameobjectUnit = GameObject.Instantiate(unitPrefab, EnemySpawnPosition(), Quaternion.identity, _poolTransform);
                        behaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
                        gameobjectUnit.SetActive(true);
                        pool.Add(behaviour);
                        return behaviour;
                    }
                }
            }
            else
            {
                if (_enemyPrefabs.TryGetValue(a_unitName, out GameObject unitPrefab))
                {

                    VSObjectPool<UnitBehaviour> newPool = new VSObjectPool<UnitBehaviour>();
                    _enemyPools.Add(a_unitName, newPool);
                    GameObject gameobjectUnit = GameObject.Instantiate(unitPrefab, EnemySpawnPosition(), Quaternion.identity, _poolTransform);
                    UnitBehaviour behavior = gameobjectUnit.GetComponent<UnitBehaviour>();
                    gameobjectUnit.SetActive(true);
                    newPool.Add(behavior);
                    return behavior;
                }                
            }
            return null;
        }


        private Vector3 EnemySpawnPosition()
        {
            return VSVectors.RandomPosition(_playerPosition.Value, _minEnemySpawnDistance, _maxEnemySpawnDistance);
        }

    }
}