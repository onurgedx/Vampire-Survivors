
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeControllerFactory : SkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        private IProperty<Vector3> _direction;
        public KnifeControllerFactory(IProperty<Vector3> a_startPosition, IProperty<Vector3> a_direction)
        {
            _startPosition = a_startPosition;
            _direction = a_direction;
        }

        public override SkillController Create()
        {
            return new KnifeController(_startPosition, _direction);
        }
    }
}