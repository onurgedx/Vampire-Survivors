using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Record;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class EnemyDamageControl
    {
        private IDamager _damager;
        private Dictionary<GameObject, int> _damageCatalouge = new Dictionary<GameObject, int>();
        public IRecorder<GameObject, int> DamagerRecorder;
        private IProperty<Vector3> _playerPosition;
        private int _playerGOHash = 0;
        private bool _hasPlayerHash = false;
        private VSTimerCounter _enemyAttackFrequency = new VSTimerCounter(0.2f);


        public EnemyDamageControl(IDamager a_damager, IProperty<Vector3> a_playerPosition)
        {
            _damager = a_damager;
            DamagerRecorder = new Recorder<GameObject, int>(_damageCatalouge);
            _playerPosition = a_playerPosition;
        }


        public void Update()
        {
            if (_enemyAttackFrequency.Process())
            {
                if (_hasPlayerHash)
                {
                    Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition.Value, 0.5f, Layers.EnemyLayerMask);
                    foreach (Collider2D collision in colliders)
                    {
                        if (_damageCatalouge.TryGetValue(collision.gameObject, out int damage))
                        {
                            _damager.Damage(_playerGOHash, damage);
                        }
                    }
                }
                else
                {
                    SeekPlayerHash();
                }
            }
        }


        private void SeekPlayerHash()
        {
            Collider2D collider = Physics2D.OverlapCircle(_playerPosition.Value, 123124, Layers.PlayerLayerMask);
            if (collider != null)
            {
                _playerGOHash = collider.gameObject.GetHashCode();
                _hasPlayerHash = true;
            }
        }
    }
}