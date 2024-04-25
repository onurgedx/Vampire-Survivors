
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "ActiveSkillBeginningData", menuName = "Data/Skills/BegginingDatas/ActiveSkillBegginingData", order = 1)]
    public class ActiveSkillBeginningData : SkillBeginingData
    {

        public float Cooldown => _cooldown;
        [SerializeField] private float _cooldown = 2;

        public int Damage => _damage;
        [SerializeField] private int _damage =40;

        public float Duration => _duration;
        [SerializeField] private float _duration=3;

        public float Size => _size;
        [SerializeField] private float _size = 1;

        public int Count => _count;
        [SerializeField] private int _count=1;

    }
}