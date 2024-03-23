using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class SuperChestFactory : ChestFactory
    {
        public SuperChestFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        protected override Collectable RetriveCollectable()
        {
            return new SuperChest();
        }
    }
}