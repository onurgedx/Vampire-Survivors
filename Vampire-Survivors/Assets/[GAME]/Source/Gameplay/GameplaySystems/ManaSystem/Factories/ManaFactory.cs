using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public abstract class ManaFactory
    {        
        protected GameObject _prefab;
        protected Transform _parent;
        public ManaFactory(GameObject a_manaPrefab, Transform a_parent)
        {
            _prefab = a_manaPrefab;
            _parent = a_parent;
        }

        public abstract (Mana, GameObject) Create(Vector3 a_position );
        


        //public T CreateManaAndBehavior<T>(System.Type a_manaType) where T : Mana
        //{

        //    if (_manaPrefabs.TryGetValue(typeof(T), out VSBehavior behavior))
        //    {
        //        Mana mana = null;
        //        if (typeof(T) == typeof(SuperMana))
        //        {
        //            mana = new SuperMana();
        //        }
        //        else if (typeof(T) == typeof(MediumMana))
        //        {

        //        }

        //    }
        //    return null;
        //}






    }
}