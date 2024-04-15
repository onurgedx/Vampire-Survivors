
using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class Skill
    {

        public float TimeCounter = 0;
        public float Cooldown { get; set; }
         


        public Skill(float a_cooldown, int a_damage)
        { 
            Cooldown = a_cooldown;
        }
    }
}