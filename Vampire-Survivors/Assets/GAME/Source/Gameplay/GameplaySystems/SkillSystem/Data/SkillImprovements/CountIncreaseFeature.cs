
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "CountIncrease", menuName = "Data/Skills/SkillLevelFeatures/CountIncrease", order = 1)]
    public class CountIncreaseFeature : SkillImprovement
    {
        public int IncreaseCount => _increaseCount;
        [SerializeField] private int _increaseCount = 1;

    }
}
