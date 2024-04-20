using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

public class PlayerUnitFactory 
{
    public (PlayerUnit ,UnitBehaviour) Create(PlayerControlSystem a_playerControlSys,
                                              GameObject a_unitPrefab,
                                              IDamageablePlayerRecorder a_damageableRecorder,
                                              PlayerHPFrame a_playerHPFrame,
                                              Property<IUnitHealth> a_unitHealth,
                                              Transform a_poolTransform)
    {
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


        GameObject gameobjectUnit = GameObject.Instantiate(a_unitPrefab, a_poolTransform);
        UnitBehaviour unitBehaviour = gameobjectUnit.GetComponent<UnitBehaviour>();
        unitBehaviour.Init(unit);
        a_playerControlSys.Init(gameobjectUnit.transform, speed); 
        a_damageableRecorder.RecordPlayer(gameobjectUnit.GetHashCode(), unit);
        a_unitHealth.SetValue(unitHealth);
        
        a_playerHPFrame.UpdateMaxHP(unitHealth.MaxHealth.Value);
        a_playerHPFrame.UpdateHP(unitHealth.CurrentHealth.Value);
        unit.Health.MaxHealthChanged += () => { a_playerHPFrame.UpdateMaxHP(unitHealth.MaxHealth.Value); };
        unit.Health.Changed += () => { a_playerHPFrame.UpdateHP(unitHealth.CurrentHealth.Value); };

        return (unit, unitBehaviour);
    }
     
}
