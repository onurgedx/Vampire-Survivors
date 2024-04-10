using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Vectors;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.Units
{
    public class UnitFactory
    {
        private float _maxEnemySpawnDistance = 25;
        private float _minEnemySpawnDistance = 10;



        private Dictionary<GameObject, VSObjectPool<UnitBehaviour>> _enemyPools = new Dictionary<GameObject, VSObjectPool<UnitBehaviour>>();
        private UnitData _enemyUnitData = new UnitData();

        private IProperty<Vector3> _playerPosition;
        public UnitFactory()
        {

        }


        public (PlayerUnit, UnitBehaviour) CreatePlayerUnit(PlayerControlSystem a_playerControlSys, GameObject a_unitPrefab)
        {
            //
            //Property<float> speed = new Property<float>(a_playerUnitData.MovementSpeed);
            //UnitHealth unitHealth = new UnitHealth(a_playerUnitData.MaxHealth);
            //Property<float> damageTaken = new Property<float>(0);
            //Property<int> attackPower = new Property<int>(a_playerUnitData.AttackPower); 
            Property<float> speed = new Property<float>(3);
            UnitHealth unitHealth = new UnitHealth(111);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(11);
            Property<float> criticalStrikeRate = new Property<float>(0);
            Property<float> criticalStrike = new Property<float>(2);
            Property<float> manaGain = new Property<float>(0);
            Property<float> itemPickupRange = new Property<float>(0);
            Property<float> hPRegenPerSecond = new Property<float>(0);
            Property<float> allMagicSize = new Property<float>(0);
            Property<float> allMagicDuration = new Property<float>(0);
            PlayerUnit unit = new PlayerUnit(criticalStrikeRate,
                                             criticalStrike,
                                             manaGain,
                                             itemPickupRange,
                                             hPRegenPerSecond,
                                             allMagicSize,
                                             allMagicDuration,
                                             unitHealth,
                                             speed,
                                             damageTaken,
                                             attackPower);


            GameObject gameobjectUnit = GameObject.Instantiate(a_unitPrefab);
            UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
            unitBehaviour.Init(unit);
            a_playerControlSys.Init(gameobjectUnit.transform, speed);
            _playerPosition = a_playerControlSys.Position;
            return (unit, unitBehaviour);
        }


        public (EnemyUnit, UnitBehaviour) CreateEnemyUnit(EnemyMovementControl a_enemyMovementControl, GameObject a_unitPrefab, UnitData a_unitData)
        {
            a_unitData = _enemyUnitData;

            Property<float> speed = new Property<float>(a_unitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_unitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_unitData.AttackPower);
            EnemyUnit unit = new EnemyUnit(unitHealth, speed, damageTaken, attackPower);
            UnitBehaviour behaviour = CreateUnitBehavior(a_unitPrefab);
            behaviour.Init(unit);
            UnitMovement unitMovement = new UnitMovement(speed, new Property<Transform>(behaviour.transform));
            a_enemyMovementControl.Add(unitMovement);
            unit.OnDead += () => { a_enemyMovementControl.Remove(unitMovement); };
            return (unit, behaviour);
        }


        private UnitBehaviour CreateUnitBehavior(GameObject a_unitPrefab)
        {
            if (_enemyPools.TryGetValue(a_unitPrefab, out VSObjectPool<UnitBehaviour> pool))
            {
                if (pool.TryRetrieve(out UnitBehaviour behaviour))
                {
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
            return VSVectors.RandomPosition(_playerPosition.Value, _minEnemySpawnDistance, _maxEnemySpawnDistance) ;
        }

    }
}