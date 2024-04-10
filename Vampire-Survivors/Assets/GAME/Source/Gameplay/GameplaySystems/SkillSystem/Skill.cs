
using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class Skill
    {

        public Action Played;
        public Action Finished;
        public Action<GameObject> Impacted;

        public float TimeCounter = 0;
        public float Cooldown { get; set; }

        public int Damage { get; private set; }
        public virtual bool Active { get; private set; }


        public Skill(float a_cooldown, int a_damage)
        {
            Damage = a_damage;
            Cooldown = a_cooldown;
        }
         

    }
}