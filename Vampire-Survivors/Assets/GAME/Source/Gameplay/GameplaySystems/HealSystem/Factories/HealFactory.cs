using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.HealSys
{
    public class HealFactory : CollectableFactory
    {
        public HealFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        protected override Collectable RetriveCollectable()
        {
            Heal heal = new Heal();
            return heal;
        }
    }
}