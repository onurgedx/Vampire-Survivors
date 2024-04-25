using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltControllerFactory : ActiveSkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        private SkillBeginingData _skillBegginingData;
        private int _skillHashCode;
        private SkillBeginingData skillBeginningData;
        private IProperty<Vector3> a_playerPosition;

        public MagicBoltControllerFactory(int a_skillHashCode, SkillBeginingData a_skillBegginingData, IProperty<Vector3> a_startPosition, ActiveSkillFactory a_skillFactory ) : base(a_skillFactory)
        {
            _skillHashCode = a_skillHashCode;
            _skillBegginingData = a_skillBegginingData;
            _startPosition = a_startPosition;
        }



        public override SkillController Create()
        {
            Skill activeSkill = _skillFactory.CrateSkill(_skillBegginingData);
            return new MagicBoltController(activeSkill, _skillHashCode, _startPosition);
        }
    }
}