using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    [CreateAssetMenu(fileName = "Level", menuName = "Data/LevelData", order = 1)]
    public class LevelDatas :ScriptableObject
    {
        public int[] RequiredExperiences => _requiredExperienceForLevel;
        [SerializeField] private int[] _requiredExperienceForLevel;
    }
}