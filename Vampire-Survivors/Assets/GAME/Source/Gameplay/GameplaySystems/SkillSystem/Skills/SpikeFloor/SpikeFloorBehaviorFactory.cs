using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{

    public class SpikeFloorBehaviorFactory : SkillBehaviorFactory
    {
        public SpikeFloorBehaviorFactory(GameObject a_prefab, IProperty<Vector3> a_startPosition) : base(a_prefab, a_startPosition)
        {
        }

        public override SkillBehaviour Create()
        {
            SpikeFloorBehavior behavior = base.Create() as SpikeFloorBehavior; 
            return behavior;
        }
    }
}