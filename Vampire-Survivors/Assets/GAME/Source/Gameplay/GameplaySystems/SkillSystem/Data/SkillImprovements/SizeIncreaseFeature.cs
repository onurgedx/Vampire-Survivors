
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "SizeIncrease", menuName = "Data/Skills/SkillLevelFeatures/SizeIncrease", order = 1)]
    public class SizeIncreaseFeature : SkillImprovement
    {
        public float SizeIncreaseRate => _sizeIncreaseRate;
        [SerializeField]private float _sizeIncreaseRate = 2;
    }
}
