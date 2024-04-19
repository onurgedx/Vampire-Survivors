using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class Damager 
    {
        public Action PlayerDead;
        private Dictionary<int, IDamageable> _damageables ;


        public Damager(Dictionary<int, IDamageable>  a_damageables)
        {
            _damageables = a_damageables;
        }
        
        
        public void Damage(int a_damageableGameObject, int a_damage)
        {
            if(_damageables.TryGetValue(a_damageableGameObject, out IDamageable damageable))
            {
                damageable.Damage(a_damage);
                if (!damageable.IsAlive)
                {
                    if(damageable is PlayerUnit)
                    {
                        PlayerDead?.Invoke();
                    }
                    _damageables.Remove(a_damageableGameObject);
                }
            }
        }

    }
}