using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    public class AIControlSystem : VSSystem
    {
        public EnemyMovementControl EnemyMovementControl { get; private set; }
        public EnemyDamageControl EnemyDamageControl { get; private set; }

        private IProperty<Vector3> _playerPosition;


        public AIControlSystem(IProperty<Vector3> a_playerPosition )
        {
            _playerPosition = a_playerPosition;
            EnemyMovementControl = new EnemyMovementControl(_playerPosition);
            EnemyDamageControl = new EnemyDamageControl(_playerPosition);
        }


        public override void Update()
        {
            base.Update();
            EnemyMovementControl.Update();
            EnemyDamageControl.Update();
        }
    }
}