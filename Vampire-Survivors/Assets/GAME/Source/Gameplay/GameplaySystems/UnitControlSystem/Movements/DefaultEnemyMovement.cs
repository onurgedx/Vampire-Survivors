using UnityEngine;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.MovementControl
{

    public class DefaultEnemyMovement : IMovement
    {
        private IProperty<Vector3> _targetPosition;
        public DefaultEnemyMovement(IProperty<Vector3> a_targetTransform)
        {
            _targetPosition = a_targetTransform;
        }

        public void Move(UnitMovementData a_unitMovementData)
        {
            Vector3 direction = Vector3.ClampMagnitude((_targetPosition.Value - a_unitMovementData.Transform.Value.position), 1);
            a_unitMovementData.Transform.Value.position += direction * Time.deltaTime * a_unitMovementData.Speed.Value;
        }
    }
}