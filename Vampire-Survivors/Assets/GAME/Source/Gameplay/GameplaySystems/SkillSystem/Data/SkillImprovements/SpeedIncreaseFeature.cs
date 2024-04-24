

using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "SpeedIncrease", menuName = "Data/Skills/SkillLevelFeatures/SpeedIncrease", order = 1)]
    public class SpeedIncreaseFeature : SkillImprovement
    {
        public int SpeedIncreaseRate => _speedIncreaseRate;
        [SerializeField] private int _speedIncreaseRate = 2;

    }
}
