using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class MediumChestFactory : ChestFactory
    {
        public MediumChestFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        protected override ICollectable RetriveCollectable()
        {
            return new MediumChest();
        }
    }
}