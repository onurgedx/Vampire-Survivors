using UnityEngine;
using VampireSurvivors.Gameplay.Layer;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class EnemyAttackSkillController : SkillController<Skill>
    {
        private IProperty<Vector3> _playerPosition;

        private GameObject _playerGameObject = null;

        public EnemyAttackSkillController(EnemyAttack a_skill, IProperty<Vector3> a_playerPosition) : base(a_skill)
        {
            _playerPosition = a_playerPosition;
        }


        protected override void Process()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_playerPosition.Value, 1, Layers.EnemyLayer);
            if (_playerGameObject == null)
            {
                Collider2D playerCollider = Physics2D.OverlapCircle(_playerPosition.Value, 1, Layers.PlayerLayer);
                if (playerCollider != null)
                {
                    _playerGameObject = playerCollider.gameObject;

                }
            }
            if (_playerGameObject != null)
            {
                foreach (Collider2D collider in colliders)
                {
                    SkillImpact?.Invoke(_playerGameObject, (int)Skill.Damage);
                }
            }
        }
    }
}