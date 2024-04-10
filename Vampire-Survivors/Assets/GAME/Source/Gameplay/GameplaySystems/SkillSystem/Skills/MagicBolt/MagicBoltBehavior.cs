
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltBehavior : SkillBehaviour
    {
        [SerializeField] private float _speed = 66;
        private Vector3 _direction = Vector3.up;
        private Vector3 _startPosition;


        public void Settings(Vector3 a_position ,Vector3 a_direction )
        {
            _startPosition = a_position;
            transform.position = a_position;
            _direction = a_direction; 
        }
 

        private void Update()
        {
            transform.position += _direction * _speed * Time.deltaTime;
            if ((_startPosition - transform.position).magnitude > 20) { Finish(); }
        }
    }
}