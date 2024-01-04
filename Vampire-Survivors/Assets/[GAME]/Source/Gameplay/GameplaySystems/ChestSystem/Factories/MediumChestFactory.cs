using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class MediumChestFactory : ChestFactory
    {
        public MediumChestFactory(GameObject a_manaPrefab, Transform a_parent) : base(a_manaPrefab, a_parent)
        {
        }

        public override (ICollectable, GameObject) Create(Vector3 a_position)
        {
            MediumChest chest = new MediumChest();
            GameObject manaGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent);
            return (chest, manaGameObject);
        }
    }
}