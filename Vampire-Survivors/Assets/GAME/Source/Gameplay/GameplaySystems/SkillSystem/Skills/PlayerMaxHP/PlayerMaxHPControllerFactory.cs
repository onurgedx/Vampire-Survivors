using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class PlayerMaxHPControllerFactory : SkillControllerFactory
    {
        private SkillBeginingData _skillBeginningData;
        private  IUnitHealth  _unitHealth; 

        public PlayerMaxHPControllerFactory(IUnitHealth  a_unitHealth,SkillBeginingData a_skillBeginningData)
        {
            _skillBeginningData = a_skillBeginningData;
               _unitHealth = a_unitHealth; 
        }

        public override SkillController Create( )
        {
            PlayerMaxHPController skillController = new PlayerMaxHPController(_unitHealth);
            skillController.Begin(_skillBeginningData);
            return skillController;
        }
    }
}