using System;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillBehaviour : VSBehavior
    {
        public Action<GameObject> Impact;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == Layers.EnemyLayer )
            {
                SkillImpact(collision.gameObject);
            }
        }

        

        public virtual void Play()
        {
            gameObject.SetActive(true);
        }
        


        public void Finish()
        {
            gameObject.SetActive(false);
        }


        private void SkillImpact(GameObject a_gameobject)
        {
            Impact?.Invoke(a_gameobject);
        }
    }
}