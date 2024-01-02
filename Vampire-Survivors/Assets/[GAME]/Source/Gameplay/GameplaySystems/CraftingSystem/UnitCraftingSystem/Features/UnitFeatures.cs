using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Units
{
    /// <summary>
    /// Responsible for Unit Features
    /// </summary>
    public class UnitFeatures
    {
        public UnitHealth UnitHealth { get; private set; }

        public Property<float> MovementSpeed { get; private set; }
        
        public Property<float> DamageTaken { get; private set; }

        public Property<int> AttackPower { get; private set; }


        public UnitFeatures(UnitHealth a_unitHealth , Property<float> a_movementSpeed, Property<float> a_damageTaken , Property<int> a_attackPower)
        {
            UnitHealth = a_unitHealth;
            MovementSpeed = a_movementSpeed;
            DamageTaken = a_damageTaken;
            AttackPower = a_attackPower;
        }


    }
}
