
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeControllerFactory : ActiveSkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        private IProperty<Vector3> _direction;
        private SkillBeginingData _skillBegginingData;
        private int _skillHashCode;

        public KnifeControllerFactory(int a_skillHashCode, SkillBeginingData a_skillBegginingData, IProperty<Vector3> a_startPosition, IProperty<Vector3> a_direction, ActiveSkillFactory a_skillFactory) : base(a_skillFactory)
        {
            _skillHashCode = a_skillHashCode;
            _skillBegginingData = a_skillBegginingData;
            _startPosition = a_startPosition;
            _direction = a_direction;
        }
          
        public override SkillController Create()
        {
            Skill activeSkill = _skillFactory.CrateSkill(_skillBegginingData);            
            return new KnifeController(activeSkill, _skillHashCode, _startPosition, _direction);
        }
    }
}
