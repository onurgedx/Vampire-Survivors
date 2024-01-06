using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.HealSys
{
    public class HealFactory : CollectableFactory
    {
        public HealFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }


        public override (ICollectable, GameObject) Create(Vector3 a_position)
        {
            Heal heal = new Heal();
            GameObject manaGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent);
            return (heal, manaGameObject);
        }         
    }
}