using System.Collections.Generic;
using UnityEngine;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class Damager
    {

        private Dictionary<GameObject, IDamageable> _damageables ;


        public Damager(Dictionary<GameObject, IDamageable>  a_damageables)
        {
            _damageables = a_damageables;
        }
        
        
        public void Damage(GameObject a_damageableBehavior, int a_damage)
        {
            if(_damageables.TryGetValue(a_damageableBehavior, out IDamageable damageable))
            {
                damageable.Damage(a_damage);
                if (!damageable.IsAlive)
                {
                    _damageables.Remove(a_damageableBehavior);
                }
            }
        }
    }
}