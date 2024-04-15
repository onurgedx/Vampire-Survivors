
using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{

    ///I DO NOT NEED this scirpt anymore. Remove it propper time
    public class EnemyDamageControl
    {
        public Action<Type,GameObject > Damage;

        private IProperty<Vector3> _playerPosition;

        private GameObject _playerGameObject = null;

        private Dictionary<Type, int> _enemyUnitsDamages;

        private VSTimerCounter _timer = new VSTimerCounter(0.2f);

        public EnemyDamageControl()
        { 
        }
        

        public void Update()
        {
            if (_timer.Process())
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition.Value, 1, Layers.EnemyLayerMask);
                if (_playerGameObject == null)
                {
                    Collider2D playerCollider = Physics2D.OverlapCircle(_playerPosition.Value, 1, Layers.PlayerLayerMask);
                    if (playerCollider != null)
                    {
                        _playerGameObject = playerCollider.gameObject;
                    }
                }
                if (_playerGameObject != null)
                {
                    foreach (Collider2D collider in colliders)
                    {
                     //   Damage(_playerGameObject, 2);//I have used here magic number to fix it later !!!
                    }
                }
            }
        }





    }
}