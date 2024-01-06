using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public abstract class ManaFactory : CollectableFactory
    {
        protected ManaFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }
    }
}