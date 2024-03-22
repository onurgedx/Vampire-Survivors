using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public abstract class ChestFactory : CollectableFactory
    {
        public ChestFactory(GameObject a_prefab, Transform a_parent) : base(a_prefab, a_parent)
        {
        }         


    }
}