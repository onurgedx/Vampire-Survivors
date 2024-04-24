
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class PlayerSpeedControllerFactory : SkillControllerFactory
    {
        private Property<float> _movementSpeed;
        private SkillBeginingData _skillBeginingData;
            
        public PlayerSpeedControllerFactory(Property<float> a_movementSpeed, SkillBeginingData a_skillBeginningData)
        {
            _skillBeginingData = a_skillBeginningData;
               _movementSpeed = a_movementSpeed;
        }

        public override SkillController Create()
        {
            PlayerSpeedController skillController = new PlayerSpeedController(_movementSpeed);
            skillController.Begin(_skillBeginingData as PassiveSkillBeginningData);
            return skillController;
        }
    }
}