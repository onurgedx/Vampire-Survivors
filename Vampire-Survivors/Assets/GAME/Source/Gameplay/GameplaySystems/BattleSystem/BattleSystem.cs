using System;
using System.Collections.Generic; 
using VampireSurvivors.Gameplay.Units; 

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    /// <summary>
    /// Controls Damageables Damage Process
    /// </summary>
    public class BattleSystem : VSSystem
    {
        public Action PlayerDead;
        public Action<IDamageable> Dead;

        public IDamager Damager { get; private set; } 
        public IDamageableRecorder DamageableRecorder { get; private set; }   
        private Dictionary<int, IDamageable> _damageables = new Dictionary<int, IDamageable>();
         

        public BattleSystem( )
        {
            Damager damager = new Damager(_damageables);
            damager.DamagableDead += OnDamagableDead;
            Damager = damager;
            DamageableRecorder = new DamageableRecorder(_damageables);   
        } 

         
        private void OnDamagableDead(IDamageable a_damageable)
        {
            if(a_damageable is PlayerUnit)
            {
                PlayerDead?.Invoke();
            }
            Dead?.Invoke(a_damageable);
        }
    }
}