using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class SuperManaFactory : ManaFactory
    {
        public SuperManaFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        public override (ICollectable, GameObject) Create(Vector3 a_position)
        {
            SuperMana mana = new SuperMana();
            GameObject manaGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent);
            return (mana, manaGameObject);
        }
    }
}