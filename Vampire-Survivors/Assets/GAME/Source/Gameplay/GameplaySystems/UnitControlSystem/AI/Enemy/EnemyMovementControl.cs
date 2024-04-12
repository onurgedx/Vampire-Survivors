using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class EnemyMovementControl
    {

        private IProperty<Vector3> _targetPosition;
        private List<UnitMovement> _movements = new List<UnitMovement>();


        public EnemyMovementControl(IProperty<Vector3> a_targetTransform)
        {            
            _targetPosition = a_targetTransform;
        }


        public void Add( UnitMovement a_unitMovement )
        {            
            _movements.Add(a_unitMovement);
        }

        
        public void Remove(UnitMovement a_unitMovement)
        {
            _movements.Remove(a_unitMovement);
        }


        public void Update()
        {
            foreach (UnitMovement movement in _movements)
            {
                Vector3 direction =Vector3.ClampMagnitude( (_targetPosition.Value - movement.Transform.Value.position),1);
                movement.Transform.Value.position += direction * Time.deltaTime * movement.Speed.Value;
            }
        }
    }
}