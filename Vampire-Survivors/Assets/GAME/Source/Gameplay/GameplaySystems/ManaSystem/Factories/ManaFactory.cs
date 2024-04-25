using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys; 

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public abstract class ManaFactory : CollectableFactory
    {
        protected ManaFactory(GameObject a_prefab, Transform a_parent) : base(a_prefab, a_parent)
        {
            
        }

        
    }
}