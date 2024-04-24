using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties; 
using VampireSurvivors.Update; 

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    /// <summary>
    /// Controls Damageables Damage Process
    /// </summary>
    public class BattleSystem : VSSystem
    {
        public Action PlayerDead;
        public Action<IDamageable> Dead;
        private Damager _damager { get; set; }
        public DamageableRecorder DamageableRecorder { get; private set; } 

        public DamageSourceTypeRecorder GameObjectDamageSourceTypeRecorder { get; set; }

        private Dictionary<int, IDamageable> _damageables = new Dictionary<int, IDamageable>();

        private Dictionary<int, int> _damageCatalouge = new Dictionary<int, int>();

        private Dictionary<GameObject, int> _enemyDamageSources = new Dictionary<GameObject, int>();

        private IProperty<Vector3> _playerPosition;
        private int _playerGameObjectHash;
        private VSTimerCounter _enemyCheckTimer = new VSTimerCounter(0.2f);

        public BattleSystem(IProperty<Vector3> a_playerPosition, IEnumerable<IAttackData> a_attackDatas)
        {
            _playerPosition = a_playerPosition;
            _damager = new Damager(_damageables);
            _damager.DamagableDead += OnDamagableDead;
            DamageableRecorder = new DamageableRecorder(_damageables); 
            DamageableRecorder.DamageablePlayerRecoreded += (int a_go) => _playerGameObjectHash = a_go;
            GameObjectDamageSourceTypeRecorder = new DamageSourceTypeRecorder(_enemyDamageSources); 
            CatalougeEnemyDamages(a_attackDatas);
        }


        private void CatalougeEnemyDamages(IEnumerable<IAttackData> a_attackDatas)
        {
            foreach (IAttackData attackData in a_attackDatas)
            {
                _damageCatalouge.Add(attackData.GetHashCode(), attackData.AttackPower);
            }
        }


        public override void Update()
        {
            base.Update();
            if (_enemyCheckTimer.Process())
            {
                EnemyDamage();
            }
        }


        public void UpdateDamage(int a_damageSourceHash, int a_newDamage)
        {
            if (!_damageCatalouge.TryAdd(a_damageSourceHash, a_newDamage))
            {
                _damageCatalouge[a_damageSourceHash] = a_newDamage;
            }
        }


        public void Damage(int a_damageSourceHash, int a_damageableObjectHash)
        {
            if (_damageCatalouge.TryGetValue(a_damageSourceHash, out int damages))
            {
                _damager.Damage(a_damageableObjectHash, damages);
            }
        }


        private void EnemyDamage()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition.Value, 0.5f, Layers.EnemyLayerMask);
            foreach (Collider2D collision in colliders)
            {
                if (_enemyDamageSources.TryGetValue(collision.gameObject, out int damageHash))
                {
                    Damage(damageHash, _playerGameObjectHash);
                }
            }
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