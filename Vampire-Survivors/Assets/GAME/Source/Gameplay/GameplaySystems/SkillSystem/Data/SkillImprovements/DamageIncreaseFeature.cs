
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "DamageIncreaseFeature", menuName = "Data/Skills/SkillLevelFeatures/DamageIncreaseFeature", order = 1)]
    public class DamageIncreaseFeature :  SkillImprovement
    {
        public int DamageIncreaseRate => _damageIncreaseRate;
        [SerializeField] private int _damageIncreaseRate = 3;

    }
}