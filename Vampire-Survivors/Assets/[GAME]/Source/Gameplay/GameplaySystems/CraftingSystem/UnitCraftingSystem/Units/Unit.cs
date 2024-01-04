using System;
using VampireSurvivors.Gameplay.Systems.BattleSys;

namespace VampireSurvivors.Gameplay.Units
{
    public abstract class Unit : IDamageable
    {        

        public int Id { get; private set; }

        public bool IsAlive => throw new NotImplementedException();

        public Action OnDead;


        public Unit()
        {            

        }


        public void Damage(int a_damage)
        {
            throw new NotImplementedException();
        }
    }
}