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

        public Dictionary<System.Type, GameObject> _unitPrefabs = new Dictionary<System.Type, GameObject>();
        

        public PlayerUnit CreatePlayerUnit(PlayerUnitData a_playerUnitData , PlayerControlSystem a_playerControlSys )
        {
            Property<float> speed = new Property<float>(a_playerUnitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_playerUnitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_playerUnitData.AttackPower);
            Property<float> criticalStrikeRate = new Property<float>(0);
            Property<float> criticalStrike = new Property<float>(2);
            Property<float> manaGain = new Property<float>(0) ;
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


            if (_unitPrefabs.TryGetValue(unit.GetType(), out GameObject prefab))
            {
                GameObject gameobjectUnit = GameObject.Instantiate(prefab);
                UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();                 
                a_playerControlSys.Init(gameobjectUnit.transform, speed);
            }

            return null;
        }
        

        public EnemyUnit CreateEnemyUnit(EnemyMovementControl a_enemyMovementControl,UnitData a_unitData )
        {

            Property<float> speed = new Property<float>(a_unitData.MovementSpeed);
            UnitHealth unitHealth = new UnitHealth(a_unitData.MaxHealth);
            Property<float> damageTaken = new Property<float>(0);
            Property<int> attackPower = new Property<int>(a_unitData.AttackPower);
            EnemyUnit unit =new EnemyUnit(unitHealth,speed, damageTaken, attackPower);

            

            if(_unitPrefabs.TryGetValue(unit.GetType(),out GameObject prefab))
            {
                GameObject gameobjectUnit = GameObject.Instantiate(prefab);
                UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
                UnitMovement unitMovement = new UnitMovement(speed,new Property<Transform>(gameobjectUnit.transform));
                a_enemyMovementControl.Add(unitMovement);
                unitHealth.Dead += () => { a_enemyMovementControl.Remove(unitMovement); };
            }            

            return null;
        }

        public AllyUnit CreateAllyUnit()
        {
            return null;
        }



    }
}