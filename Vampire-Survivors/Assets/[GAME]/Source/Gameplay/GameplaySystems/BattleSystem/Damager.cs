using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class Damager
    {
        private Dictionary<Collider, IDamageable> _damageables ;

        public Damager(Dictionary<Collider, IDamageable>  a_damageables)
        {
            _damageables = a_damageables;
        }
        
        
        public void Damage(Collider a_damageableCollider, int a_damage)
        {
            if(_damageables.TryGetValue(a_damageableCollider, out IDamageable damageable))
            {
                damageable.Damage(a_damage);
                if (!damageable.IsAlive)
                {
                    _damageables.Remove(a_damageableCollider);
                }
            }
        }
    }
}