using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class BigManaFactory : ManaFactory
    {
        public BigManaFactory(GameObject a_manaPrefab, Transform a_parent) :base(a_manaPrefab, a_parent)
        {
           
        }

        
        protected override ICollectable RetriveCollectable()
        {
            throw new System.NotImplementedException();
        }
    }


}