using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    public class EnemyUnit : Unit
    {
        public EnemyUnit(UnitHealth a_unitHealth,
                         Property<float> a_movementSpeed,
                         Property<float> a_damageTaken,
                         Property<int> a_attackPower) : base(a_unitHealth, a_movementSpeed, a_damageTaken, a_attackPower)
        {
        }
    }
}