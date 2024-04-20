using UnityEngine;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeBehavior :SkillBehaviour
{
        [SerializeField] private float _speed =30;
        private Vector3 _direction;
        private Vector3 _startPosition;
        public void Settings(Vector3 a_direction,Vector3 a_position)
        {
            _direction = a_direction;
            _startPosition = a_position;
            transform.position = a_position;
        }

        private void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
            if ((_startPosition - transform.position).magnitude > 20) { Finish(); }
        }

    }
}