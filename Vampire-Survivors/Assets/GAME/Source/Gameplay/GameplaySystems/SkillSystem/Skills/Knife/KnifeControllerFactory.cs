
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeControllerFactory : ActiveSkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        private IProperty<Vector3> _direction;
        private SkillBeginingData _skillBegginingData;
        private IDamager _damager;

        public KnifeControllerFactory(IDamager a_damager, SkillBeginingData a_skillBegginingData, IProperty<Vector3> a_startPosition, IProperty<Vector3> a_direction, ActiveSkillFactory a_skillFactory) : base(a_skillFactory)
        {
            _damager = a_damager;
            _skillBegginingData = a_skillBegginingData;
            _startPosition = a_startPosition;
            _direction = a_direction;
        }
          
        public override SkillController Create()
        {
            Skill activeSkill = _skillFactory.CrateSkill(_skillBegginingData);            
            return new KnifeController(activeSkill, _damager, _startPosition, _direction);
        }
    }
}
