
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class PlayerSpeedController : SkillController
    {
        private Property<float> _movementSpeed;
        public PlayerSpeedController(Property<float> a_movementSpeed)
        {
            _movementSpeed = a_movementSpeed;
        }

        public override void LevelUp(SkillImprovement[] a_skillImprovments)
        {
            foreach (SkillImprovement skillImprovment in a_skillImprovments)
            {
                if (skillImprovment is SpeedIncreaseFeature speedIncreaseFeature)
                {
                    _movementSpeed.SetValue(_movementSpeed.Value * (100 + speedIncreaseFeature.SpeedIncreaseRate) * 0.01f);
                }
            }
        }
    }
}