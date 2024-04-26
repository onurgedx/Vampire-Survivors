using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltControllerFactory : ActiveSkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        private SkillBeginingData _skillBegginingData;
        private IDamager _damager;  

        public MagicBoltControllerFactory(IDamager a_damager,
                                          SkillBeginingData a_skillBegginingData,
                                          IProperty<Vector3> a_startPosition,
                                          ActiveSkillFactory a_skillFactory) : base(a_skillFactory)
        {
            _damager = a_damager;
            _skillBegginingData = a_skillBegginingData;
            _startPosition = a_startPosition;
        }



        public override SkillController Create()
        {
            Skill activeSkill = _skillFactory.CrateSkill(_skillBegginingData);
            return new MagicBoltController(activeSkill, _damager, _startPosition);
        }
    }
}