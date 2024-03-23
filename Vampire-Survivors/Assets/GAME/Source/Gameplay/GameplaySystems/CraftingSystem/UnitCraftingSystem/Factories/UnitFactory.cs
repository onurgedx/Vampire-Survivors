using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    public class UnitFactory
    {


        public UnitFactory()
        {

        }


        public (PlayerUnit, UnitBehaviour) CreatePlayerUnit( PlayerControlSystem a_playerControlSys, GameObject a_unitPrefab)
        {
            //
            //Property<float> speed = new Property<float>(a_playerUnitData.MovementSpeed);
            //UnitHealth unitHealth = new UnitHealth(a_playerUnitData.MaxHealth);
            //Property<float> damageTaken = new Property<float>(0);
            //Property<int> attackPower = new Property<int>(a_playerUnitData.AttackPower); 
            Property<float> speed = new Property<float>(11);
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
            a_playerControlSys.Init(gameobjectUnit.transform, speed);

            return (unit, unitBehaviour);
        }


        public EnemyUnit CreateEnemyUnit(EnemyMovementControl a_enemyMovementControl, UnitData a_unitData)
        {

            Property<float> speed = new Property<float>(a_unitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_unitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_unitData.AttackPower);
            EnemyUnit unit = new EnemyUnit(unitHealth, speed, damageTaken, attackPower);



            //if (_unitPrefabs.TryGetValue(unit.GetType(), out GameObject prefab))
            //{
            //    GameObject gameobjectUnit = GameObject.Instantiate(prefab);
            //    UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
            //    UnitMovement unitMovement = new UnitMovement(speed, new Property<Transform>(gameobjectUnit.transform));
            //    a_enemyMovementControl.Add(unitMovement);
            //    unitHealth.Dead += () => { a_enemyMovementControl.Remove(unitMovement); };
            //}

            return null;
        }

        public AllyUnit CreateAllyUnit()
        {
            return null;
        }



    }
}