using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class MediumManaFactory : ManaFactory
    {
        public MediumManaFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        protected override Collectable RetriveCollectable()
        {
            return new MediumMana();
        }
    }
}