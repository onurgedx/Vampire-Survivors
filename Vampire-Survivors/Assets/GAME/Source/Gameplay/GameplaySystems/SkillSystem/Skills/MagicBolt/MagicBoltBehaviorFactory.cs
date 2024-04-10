 
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{


    public class MagicBoltBehaviorFactory : SkillBehaviorFactory
    {
        public MagicBoltBehaviorFactory(GameObject a_prefab, IProperty<Vector3> a_startPosition) : base(a_prefab, a_startPosition)
        {
        }

        public override SkillBehaviour Create()
        {
            MagicBoltBehavior behavior = base.Create() as MagicBoltBehavior;
            behavior.Impact +=(_)=> behavior.Finish();
           return behavior;
        }
    }

}