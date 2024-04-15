using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Collisions
{     
    public class CollisionCheckerBehavior : VSBehavior
    { 

        public Action<Collider2D> TriggerStay;

        [SerializeField] private Collider2D _collider;


        public void Init(LayerMask a_includedLayerMask)
        {
            _collider.includeLayers = a_includedLayerMask;
        }
               
        public void UpdatePosition(Vector3 a_position)
        {
            transform.position = a_position;
        }


        private void OnTriggerStay2D(Collider2D collision)
        {            
            TriggerStay?.Invoke(collision);
        }
    }
}