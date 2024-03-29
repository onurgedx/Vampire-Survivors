using System.Collections.Generic;
using UnityEngine;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class BattleSystem : VSSystem
    {
        public Damager Damager { get; private set; }
        public DamageableRecorder DamageRecorder { get; private set; }

        private Dictionary<Collider, IDamageable> _damageables = new Dictionary<Collider, IDamageable>();        


        public BattleSystem()
        {
            Damager = new Damager(_damageables);
            DamageRecorder = new DamageableRecorder(_damageables);
        }
    }
}