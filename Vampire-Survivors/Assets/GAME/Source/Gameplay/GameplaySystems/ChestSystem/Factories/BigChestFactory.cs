using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class BigChestFactory : ChestFactory
    {

        public BigChestFactory(GameObject a_prefab, Transform a_parent) : base(a_prefab, a_parent)
        {
        }
                

        protected override ICollectable RetriveCollectable()
        {
            BigChest chest = new BigChest();
            return chest;
        }
    }
}