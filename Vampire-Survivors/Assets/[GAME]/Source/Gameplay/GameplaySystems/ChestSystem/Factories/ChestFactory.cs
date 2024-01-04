using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public abstract class ChestFactory : CollectableFactory
    {
        public ChestFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }         
    }
}