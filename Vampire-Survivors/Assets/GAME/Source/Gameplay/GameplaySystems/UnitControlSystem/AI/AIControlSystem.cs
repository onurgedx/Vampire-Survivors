using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.AIControl
{
    /// <summary>
    /// Controls AI
    /// </summary>
    public class AIControlSystem : VSSystem
    {
        public EnemyDamageControl EnemyDamageControl { get; private set; }
        public EnemyMovementControl EnemyMovementControl { get; private set; }
        private IProperty<Vector3> _playerPosition;


        public AIControlSystem(IProperty<Vector3> a_playerPosition ,IDamager a_damager)
        {
            _playerPosition = a_playerPosition;
            EnemyMovementControl = new EnemyMovementControl(_playerPosition);
            EnemyDamageControl = new EnemyDamageControl(a_damager, a_playerPosition);
        }


        public override void Update()
        {
            base.Update();
            EnemyMovementControl.Update();
            EnemyDamageControl.Update();


        }
    }
}