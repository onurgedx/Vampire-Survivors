using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class EnemyMovementControl
    {

        private Transform _targetTransform;
        private List<UnitMovement> _movements = new List<UnitMovement>();


        public EnemyMovementControl(Transform a_targetTransform)
        {            
            _targetTransform = a_targetTransform;
        }


        public void Add( UnitMovement a_unitMovement )
        {            
            _movements.Add(a_unitMovement);
        }

        
        public void Remove(UnitMovement a_unitMovement)
        {
            _movements.Remove(a_unitMovement);
        }


        private void Move()
        {
            foreach (UnitMovement movement in _movements)
            {
                Vector3 direction =Vector3.ClampMagnitude( (_targetTransform.position - movement.Transform.Value.position),1);
                movement.Transform.Value.position += direction * Time.deltaTime * movement.Speed.Value;
            }
        }




    }
}