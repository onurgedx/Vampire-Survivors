using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeBehaviorFactory : SkillBehaviorFactory
    {
        public KnifeBehaviorFactory(GameObject a_prefab, IProperty<Vector3> a_startPosition) : base(a_prefab, a_startPosition)
        {
        }
    }
}