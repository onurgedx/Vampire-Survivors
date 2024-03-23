using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class SmallManaFactory : ManaFactory
    {
        public SmallManaFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        protected override Collectable RetriveCollectable()
        {
            return new SmallMana();
        }
    }
}