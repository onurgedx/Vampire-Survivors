
using System;
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class Skill : ISkill
    {

        public float TimeCounter = 0;
        public float Cooldown { get; set; }
        public float Duration { get; set; }
        public int Damage { get; set; } 
        public float Size { get; set; }
        public int Count { get; set; }

        public Skill(float a_cooldown, float a_duration, int a_damage,   float a_size,int a_count)
        {
            Cooldown = a_cooldown;
            Duration = a_duration;
            Damage = a_damage; 
            Size = a_size;
            Count = a_count;
        }
    }
}