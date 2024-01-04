using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public abstract class ManaFactory :CollectableFactory
    {        
        protected GameObject _prefab;
        protected Transform _parent;
        public ManaFactory(GameObject a_manaPrefab, Transform a_parent)
        {
            _prefab = a_manaPrefab;
            _parent = a_parent;
        }              
    }
}