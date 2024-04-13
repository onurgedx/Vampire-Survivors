using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.MovementControl;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class EnemyMovementControl
    {

        private IProperty<Vector3> _targetPosition;
        private Dictionary<Unit,UnitMovementData> _moveableUnitsData = new Dictionary<Unit, UnitMovementData>();

        private Dictionary<System.Type, IMovement> _movements = new Dictionary<System.Type, IMovement>();

        public EnemyMovementControl(IProperty<Vector3> a_targetTransform)
        {            
            _targetPosition = a_targetTransform;
            AdjustMovements();
        }


        public void Add(Unit a_unit, UnitMovementData a_unitMovement )
        {            
            _moveableUnitsData.Add(a_unit, a_unitMovement);
        }

        
        public void Remove(Unit a_unit )
        {
            _moveableUnitsData.Remove(a_unit);
        }


        public void Update()
        {
            foreach ((Unit unit, UnitMovementData unitMovementData) in _moveableUnitsData)
            {
                if(_movements.TryGetValue(unit.GetType(),out IMovement movement))
                {
                    movement.Move(unitMovementData);
                }                   
            }
        }


        private void AdjustMovements()
        {
            _movements.Add(typeof(EnemyUnit), new DefaultEnemyMovement(_targetPosition));

        }

    }
}