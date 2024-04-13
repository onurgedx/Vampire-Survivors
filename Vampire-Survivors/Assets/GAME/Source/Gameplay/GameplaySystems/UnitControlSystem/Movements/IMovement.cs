 
using UnityEngine;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems.MovementControl
{

    public interface IMovement 
    {
        public void Move(UnitMovementData a_unitMovementData);
    }
}