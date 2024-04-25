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
        public int Id { get; private set; }

        public bool IsAlive => Health.CurrentHealth.Value>0;

        public Action OnDead;

        public UnitHealth Health { get; private set; }

        public Property<float> MovementSpeed { get; private set; }

        public Property<float> DamageTaken { get; private set; }

        public Property<int> AttackPower { get; private set; }


        public Unit(UnitHealth a_unitHealth, Property<float> a_movementSpeed, Property<float> a_damageTaken, Property<int> a_attackPower)
        {
            Health = a_unitHealth;
            Health.Dead += Dead;
            MovementSpeed = a_movementSpeed;
            DamageTaken = a_damageTaken;
            AttackPower = a_attackPower;
        }


        /// <summary>
        /// Unit Health decrease
        /// </summary>
        /// <param name="a_rawDamage"></param>
        public void Damage(int a_rawDamage)
        {
            int conculusionDamage = ConculusionDamage((Math.Abs(a_rawDamage) * -1));
            Health.UpdateCurrentHealth(conculusionDamage);            
        }


        private int ConculusionDamage( int a_rawDamage)
        {
            int conculusionDamage ;
            conculusionDamage = (int)( a_rawDamage + a_rawDamage * DamageTaken.Value);
            return conculusionDamage;
        }


        private void Dead()
        {
            OnDead?.Invoke();
        }
    }
}