using System;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    public abstract class Unit : IDamageable
    {
        public int Id { get; private set; }

        public bool IsAlive => Health.CurrentHealth.Value>0;

        public Action OnDead=>Health.Dead;

        public UnitHealth Health { get; private set; }

        public Property<float> MovementSpeed { get; private set; }

        public Property<float> DamageTaken { get; private set; }

        public Property<int> AttackPower { get; private set; }


        public Unit(UnitHealth a_unitHealth, Property<float> a_movementSpeed, Property<float> a_damageTaken, Property<int> a_attackPower)
        {
            Health = a_unitHealth;
            MovementSpeed = a_movementSpeed;
            DamageTaken = a_damageTaken;
            AttackPower = a_attackPower;
        }


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
    }
}