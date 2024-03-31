using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [Serializable]
    public class SkillData
    {
        public string Id => _id;
        [SerializeField] private string _id;

        public float Cooldown => _cooldown;
        [SerializeField] private float _cooldown;

        public float Damage => _damage;
        [SerializeField] float _damage;

        public GameObject Prefab => _prefab;
        [SerializeField] private GameObject _prefab;

    }
}