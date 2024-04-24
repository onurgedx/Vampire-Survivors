
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "PlayerMaxHPIncreaseFeature", menuName = "Data/Skills/SkillLevelFeatures/PlayerMaxHPIncreaseFeature", order = 1)]

    public class PlayerMaxHPIncreaseFeature : SkillImprovement
    {
        public int PlayerMaxHPIncreaseAmount => _playerMaxHPIncreaseAmount;
        [SerializeField]private int _playerMaxHPIncreaseAmount = 30;

    }
}