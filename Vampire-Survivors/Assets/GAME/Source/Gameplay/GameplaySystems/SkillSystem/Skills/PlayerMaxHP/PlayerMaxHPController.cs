
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class PlayerMaxHPController : SkillController
    {

        private  IUnitHealth  _unitHealth;

        public PlayerMaxHPController( IUnitHealth  a_playerUnitHealth)
        {
            _unitHealth = a_playerUnitHealth;
        }

        public void Begin(SkillBeginingData a_skillBeginningData)
        {
            if(a_skillBeginningData is PassiveSkillBeginningData passiveBeginningData)
            {
                _unitHealth.UpdateMaxHealth(passiveBeginningData.IncreaseAmount); 
                _unitHealth.UpdateCurrentHealth(passiveBeginningData.IncreaseAmount);
            }
        }

        public override void LevelUp(SkillImprovement[] a_skillImprovments)
        {
            foreach (var item in a_skillImprovments)
            {
                if(item is PlayerMaxHPIncreaseFeature maxHPIncreaseFeature)
                {
                    _unitHealth.UpdateMaxHealth(maxHPIncreaseFeature.PlayerMaxHPIncreaseAmount);
                    _unitHealth.UpdateCurrentHealth(maxHPIncreaseFeature.PlayerMaxHPIncreaseAmount);
                }

            }
        }
    }
}