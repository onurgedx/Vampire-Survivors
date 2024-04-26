using System;
using System.Collections.Generic;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    /// <summary>
    /// Responsible all damage process
    /// </summary>
    public class Damager  : IDamager
    {
        public Action<IDamageable> DamagableDead; 
        private Dictionary<int, IDamageable> _damageables ;


        public Damager(Dictionary<int, IDamageable>  a_damageables)
        {
            _damageables = a_damageables;
        }
        
        
        public void Damage(int a_damageableGameObjectHashCode, int a_damage)
        {
            if(_damageables.TryGetValue(a_damageableGameObjectHashCode, out IDamageable damageable))
            {
                damageable.Damage(a_damage);
                if (!damageable.IsAlive)
                {
                    DamagableDead?.Invoke(damageable); 
                    _damageables.Remove(a_damageableGameObjectHashCode);
                }
            }
        }

    }
}