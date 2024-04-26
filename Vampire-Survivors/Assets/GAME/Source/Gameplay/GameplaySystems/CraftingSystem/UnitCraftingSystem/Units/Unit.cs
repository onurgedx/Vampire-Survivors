using System;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    /// <summary>
    /// Unit and Its Features
    /// </summary>
    public abstract class Unit : IDamageable
    { 
        public bool IsAlive => Health.CurrentHealth.Value>0;

        public Action OnDead;

        public UnitHealth Health { get; private set; }


        public Unit(UnitHealth a_unitHealth)
        {
            Health = a_unitHealth;
            Health.Dead += Dead;
        }


        /// <summary>
        /// Unit Health decrease
        /// </summary>
        /// <param name="a_rawDamage"></param>
        public void Damage(int a_rawDamage)
        {
            int conculusionDamage =  (Math.Abs(a_rawDamage) * -1) ;
            Health.UpdateCurrentHealth(conculusionDamage);            
        }
         


        private void Dead()
        {
            OnDead?.Invoke();
        }
    }
}