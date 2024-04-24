
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class PlayerSpeedControllerFactory : SkillControllerFactory
    {
        private Property<float> _movementSpeed;
        public PlayerSpeedControllerFactory(Property<float> a_movementSpeed)
        {
            _movementSpeed = a_movementSpeed;
        }

        public override SkillController Create()
        {
            return new PlayerSpeedController(_movementSpeed);

        }
    }
}