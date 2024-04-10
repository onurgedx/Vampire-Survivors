using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class EnemyAttackSkillController : SkillController 
    {
        private IProperty<Vector3> _playerPosition;

        private GameObject _playerGameObject = null;

        public EnemyAttackSkillController( IProperty<Vector3> a_playerPosition) : base()
        {
            _playerPosition = a_playerPosition;
        }

        public override void Play(SkillBehaviour a_skillBehavior)
        {
            throw new System.NotImplementedException();
        }

        protected  void PlaySkill( )
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
                    Impact(_playerGameObject); 
                }
            }
        }
    }
}