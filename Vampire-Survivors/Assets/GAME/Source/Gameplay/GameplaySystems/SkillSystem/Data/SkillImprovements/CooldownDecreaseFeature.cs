using UnityEngine;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "CooldownDecrease", menuName = "Data/Skills/SkillLevelFeatures/CooldownDecrease", order = 1)]
    public class CooldownDecreaseFeature :   SkillImprovement
    {
        public int CooldownDecreaseRate => _cooldownDecreaseRate;
        [SerializeField] private int _cooldownDecreaseRate = 3;
    }
}