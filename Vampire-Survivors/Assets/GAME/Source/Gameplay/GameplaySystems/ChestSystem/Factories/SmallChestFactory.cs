using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class SmallChestFactory : ChestFactory
    {
        public SmallChestFactory(GameObject a_prefab, Transform a_parent) : base(a_prefab, a_parent)
        {
        }

        protected override ICollectable RetriveCollectable()
        {
            return new SmallChest();
        }
    }
}