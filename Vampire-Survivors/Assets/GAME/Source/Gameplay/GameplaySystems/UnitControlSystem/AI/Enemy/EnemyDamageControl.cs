
using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class EnemyDamageControl 
    {
        public Action<GameObject, int> Damage;

        private IProperty<Vector3> _playerPosition;

        private GameObject _playerGameObject = null;

        private Dictionary<Type, int> _enemyUnitsDamages;

        public EnemyDamageControl(IProperty<Vector3> a_playerPosition )
        {
            _playerPosition = a_playerPosition; 
        }


        public void Update()
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
                    Damage(_playerGameObject, 2);//I have used here magic number to fix it later !!!
                }
            }
        }


        

        
    }
}