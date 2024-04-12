
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorControllerFactory : SkillControllerFactory
    {
        private IProperty<Vector3> _startPosition;
        public SpikeFloorControllerFactory(IProperty<Vector3> a_startPosition)
        {
            _startPosition = a_startPosition;
        }

        public override SkillController Create()
        {
            return new SpikeFloorController(_startPosition);
        }
    }
}