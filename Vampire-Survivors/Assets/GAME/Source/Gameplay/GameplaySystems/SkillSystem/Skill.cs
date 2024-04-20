
using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class Skill
    {

        public float TimeCounter = 0;
        public float Cooldown { get; set; }
        public float Duration { get; set; }
         


        public Skill(float a_cooldown, float a_duration )
        { 
            Cooldown = a_cooldown;
            Duration = a_duration; 
        }
    }
}