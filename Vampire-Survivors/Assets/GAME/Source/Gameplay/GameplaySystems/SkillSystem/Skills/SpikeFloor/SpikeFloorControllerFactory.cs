
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorControllerFactory : SkillControllerFactory
    {
        private IProperty<Vector3> _startPosition; 
        private SkillBeginingData _skillBegginingData;
        private int _skillHashCode;
        public SpikeFloorControllerFactory(int a_skillHashCode, SkillBeginingData a_skillBegginingData,IProperty<Vector3> a_startPosition)
        {
            _skillHashCode = a_skillHashCode;
            _skillBegginingData = a_skillBegginingData;
            _startPosition = a_startPosition;
        }

        public override  SkillController Create( )
        {
            Skill activeSkill = null;
            if (_skillBegginingData is ActiveSkillBeginningData activeBeginData)
            {
                activeSkill = new Skill(activeBeginData.Cooldown, 1, activeBeginData.Damage, 1, 1);
            }
            return new SpikeFloorController(activeSkill, _skillHashCode, _startPosition);
        }
    }
}