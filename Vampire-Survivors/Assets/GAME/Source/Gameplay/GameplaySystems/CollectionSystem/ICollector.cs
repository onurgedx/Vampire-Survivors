 
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public interface ICollector
    {
        public Collider2D[] Collect();
        public void Collect(Collectable a_collectable);
    }
}