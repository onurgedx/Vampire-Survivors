using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    /// <summary>
    /// Unit for Player
    /// </summary>
    public class PlayerUnit : Unit
    {
        public Property<float> CriticalStrikeRate { get; private set; } // %3

        public Property<float> CriticalStrike { get; private set; } //%200

        public Property<float> ManaGain { get; private set; } //+0%

        public Property<float> ItemPickupRange { get; private set; }
        
        public Property<float> HPRegenPerSecond { get; private set; }

        public Property<float> AllMagicSize { get; private set; } //+0%

        public Property<float> AllMagicDuration { get; private set; } // +0%
        
        public PlayerUnit(Property<float> a_criticalStrikeRate,
                          Property<float> a_criticalStrike,
                          Property<float> a_manaGain,
                          Property<float> a_itemPickupRange,
                          Property<float> a_hPRegenPerSecond,
                          Property<float> a_allMagicSize,
                          Property<float> a_allMagicDuration,
                          UnitHealth a_unitHealth,
                          Property<float> a_movementSpeed,
                          Property<float> a_damageTaken,
                          Property<int> a_attackPower) : base(a_unitHealth, a_movementSpeed, a_damageTaken, a_attackPower)
        {
            CriticalStrikeRate = a_criticalStrikeRate;
            CriticalStrike = a_criticalStrike;
            ManaGain = a_manaGain;
            ItemPickupRange = a_itemPickupRange;
            HPRegenPerSecond = a_hPRegenPerSecond;
            AllMagicSize = a_allMagicSize;
            AllMagicDuration = a_allMagicDuration;
        }
    }
}