using System;
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Update;
using static VampireSurvivors.Gameplay.Systems.SkillSys.KnifeLevels;
using static VampireSurvivors.Gameplay.Systems.SkillSys.MagicBoltLevels;
using static VampireSurvivors.Gameplay.Systems.SkillSys.SpikeFloorLevels;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class BattleSystem : VSSystem
    {
        public Action PlayerDead;
        private Damager _damager { get; set; }
        public DamageableRecorder DamageRecorder { get; private set; }
        public DamageSourceTypeRecorder GameObjectDamageSourceTypeRecorder { get; set; }

        private Dictionary<GameObject, IDamageable> _damageables = new Dictionary<GameObject, IDamageable>();

        private Dictionary<System.Type, int> _damageCatalouge = new Dictionary<System.Type, int>()
        {

            { typeof(SpikeFloorLevel1) , 100 },
            { typeof(SpikeFloorLevel2) , 150},
            { typeof(SpikeFloorLevel3) , 200 },
            { typeof(SpikeFloorLevel4) , 250},
            { typeof(SpikeFloorLevel5) , 300 },
            { typeof(SpikeFloorLevel6) , 350},
            { typeof(SpikeFloorLevel7) , 350 },
            { typeof(KnifeLevel1) , 10 },
            { typeof(KnifeLevel2) , 15},
            { typeof(KnifeLevel3) , 20 },
            { typeof(KnifeLevel4) , 25},
            { typeof(KnifeLevel5) , 30 },
            { typeof(KnifeLevel6) , 35 },
            { typeof(KnifeLevel7) , 35 },
            { typeof(MagicBoltLevel1) , 10 },
            { typeof(MagicBoltLevel2) , 15},
            { typeof(MagicBoltLevel3) , 20 },
            { typeof(MagicBoltLevel4) , 25},
            { typeof(MagicBoltLevel5) , 30 },
            { typeof(MagicBoltLevel6) , 35 },
            { typeof(MagicBoltLevel7) , 35 },
            { typeof(EnemyUnit) , 10 }
        };

        private Dictionary<GameObject, Type> _damageSourceTypes = new Dictionary<GameObject, Type>();

        private IProperty<Vector3> _playerPosition; 
        private GameObject _playerGameObject;
        private VSTimerCounter _enemyCheckTimer = new VSTimerCounter(0.2f);
        public BattleSystem(IProperty<Vector3> a_playerPosition)
        {
            _playerPosition = a_playerPosition;
            _damager = new Damager(_damageables);
            DamageRecorder = new DamageableRecorder(_damageables);
            DamageRecorder.DamageablePlayerRecoreded += (GameObject a_go) => _playerGameObject = a_go;
            GameObjectDamageSourceTypeRecorder = new DamageSourceTypeRecorder(_damageSourceTypes);
            _damager.PlayerDead += OnPlayerDead; 
        }


        public override void Update()
        {
            base.Update();
            if (_enemyCheckTimer.Process())
            {
                EnemyDamage();
            }
        } 


        public void Damage(System.Type a_damageSource, GameObject a_damageableObject)
        {
            if (_damageCatalouge.TryGetValue(a_damageSource, out int damage))
            {
                _damager.Damage(a_damageableObject, damage);
            }
        }


        private void EnemyDamage( )
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition.Value, 0.5f, Layers.EnemyLayerMask);
            foreach (Collider2D collision in colliders)
            {
                if (_damageSourceTypes.TryGetValue(collision.gameObject, out Type damageType))
                {
                    Damage(damageType, _playerGameObject);
                }
            }
        }


        private void OnPlayerDead()
        {
            PlayerDead?.Invoke();
        }
    }
}