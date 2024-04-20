using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltControllerFactory : SkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        public MagicBoltControllerFactory(  IProperty<Vector3> a_startPosition)
        {
            _startPosition = a_startPosition;
        }

        public override SkillController Create(Skill a_skill, int a_skillLevelHash)
        {
            return new MagicBoltController(a_skill, a_skillLevelHash, _startPosition);
        }
    }
}