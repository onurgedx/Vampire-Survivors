
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorBehavior : SkillBehaviour
    {

        [SerializeField] private Animator _animator;

        private readonly static int _spikeFloorAnimationHash = Animator.StringToHash("Play");


        public void Settings(Vector3 a_position)
        { 
            transform.position = a_position; 
        }

        public override void Play()
        {
            base.Play();
            _animator.SetTrigger(_spikeFloorAnimationHash);

        }
    }
}