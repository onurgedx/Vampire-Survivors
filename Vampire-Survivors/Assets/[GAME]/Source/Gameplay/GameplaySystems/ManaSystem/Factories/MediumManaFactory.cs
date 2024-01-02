using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class MediumManaFactory : ManaFactory
    {
        public MediumManaFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        public override (Mana, GameObject) Create(Vector3 a_position)
        {
            MediumMana mana = new MediumMana();
            GameObject manaGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent);
            return (mana, manaGameObject);
        }
    }
}