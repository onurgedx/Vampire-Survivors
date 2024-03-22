using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public abstract class ManaFactory : CollectableFactory
    {
        protected ManaFactory(GameObject a_prefab, Transform a_parent) : base(a_prefab, a_parent)
        {
            
        }

        
    }
}