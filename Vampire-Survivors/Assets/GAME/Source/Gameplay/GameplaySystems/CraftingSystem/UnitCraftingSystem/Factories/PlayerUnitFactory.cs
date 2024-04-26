using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems
{
    public class PlayerUnitFactory
    {
        public PlayerUnitFactory()
        {
        }

        /// <summary>
        /// Creates PlayerUnit and Its UnitBehavior
        /// </summary>
        /// <param name="a_playerControlSys"></param>
        /// <param name="a_unitPrefab"></param>
        /// <param name="a_damageableRecorder"></param>
        /// <param name="a_playerHPFrame"></param>
        /// <param name="a_poolTransform"></param>
        /// <returns></returns>
        public (PlayerUnit, UnitBehaviour) Create(PlayerControlSystem a_playerControlSys,
                                                  GameObject a_unitPrefab,
                                                  IDamageableRecorder a_damageableRecorder,
                                                  PlayerHPFrame a_playerHPFrame,
                                                  Transform a_poolTransform)
        {
            Property<float> speed = new Property<float>(3);
            UnitHealth unitHealth = new UnitHealth(111);
            PlayerUnit unit = new PlayerUnit(unitHealth, speed);

            GameObject gameobjectUnit = GameObject.Instantiate(a_unitPrefab, a_poolTransform);
            UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
            unitBehaviour.Init(unit);
            a_playerControlSys.Init(gameobjectUnit.transform, speed);
            a_damageableRecorder.Record(gameobjectUnit.GetHashCode(), unit);

            a_playerHPFrame.UpdateMaxHP(unitHealth.MaxHealth.Value);
            a_playerHPFrame.UpdateHP(unitHealth.CurrentHealth.Value);
            unit.Health.MaxHealthChanged += () => { a_playerHPFrame.UpdateMaxHP(unitHealth.MaxHealth.Value); };
            unit.Health.Changed += () => { a_playerHPFrame.UpdateHP(unitHealth.CurrentHealth.Value); };

            return (unit, unitBehaviour);
        }

    }
}