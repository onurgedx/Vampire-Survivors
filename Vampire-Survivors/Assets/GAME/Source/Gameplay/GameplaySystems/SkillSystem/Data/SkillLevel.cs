using System;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "SkillLevel", menuName = "Data/Skills/SkillLevel", order = 1)]
     
    public class SkillLevel : ScriptableObject, IAttackData
    {
        public float Cooldown => _cooldown;
        [SerializeField] private float _cooldown=1;

        public float Duration => _duration;
        [SerializeField] private float _duration;

        public int AttackPower => _attackPower;
        [SerializeField] int _attackPower=1;
    }
}