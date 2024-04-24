
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



    }
}