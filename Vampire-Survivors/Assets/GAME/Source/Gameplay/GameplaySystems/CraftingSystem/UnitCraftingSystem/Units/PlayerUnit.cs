using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    /// <summary>
    /// Unit for Player
    /// </summary>
    public class PlayerUnit : Unit
    {
        public Property<float> MovementSpeed { get; private set; }
        public PlayerUnit(UnitHealth a_unitHealth,Property<float> a_movementSpeed) : base(a_unitHealth)
        {
            MovementSpeed = a_movementSpeed;
        }
    }
}