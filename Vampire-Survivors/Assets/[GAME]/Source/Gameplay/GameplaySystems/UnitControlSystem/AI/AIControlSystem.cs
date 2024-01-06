using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class AIControlSystem : VSSystem
    {

        public EnemyMovementControl EnemyMovementControl { get; private set; }

        public AIControlSystem(Transform a_playerTransform )
        {

        }


    }
}