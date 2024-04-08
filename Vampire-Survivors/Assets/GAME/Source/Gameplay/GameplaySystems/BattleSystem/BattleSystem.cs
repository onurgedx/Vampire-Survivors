using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class BattleSystem : VSSystem
    {
        public Damager Damager { get; private set; }
        public DamageableRecorder DamageRecorder { get; private set; }

        private Dictionary<GameObject, IDamageable> _damageables = new Dictionary<GameObject, IDamageable>();
         

        public BattleSystem( )
        {
            Damager = new Damager(_damageables);
            DamageRecorder = new DamageableRecorder(_damageables); 
        } 

    }
}