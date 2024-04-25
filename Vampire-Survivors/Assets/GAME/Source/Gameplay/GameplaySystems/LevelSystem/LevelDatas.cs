using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CraftingSys;
using VampireSurvivors.Gameplay.Systems.SkillSys;

namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    /// <summary>
    /// Contains Level Datas
    /// </summary>
    [CreateAssetMenu(fileName = "Level", menuName = "Data/LevelData", order = 1)]
    
    public class LevelDatas : ScriptableObject
    {
        public float WaveDuration => _waveDuration;
        [SerializeField] private float _waveDuration=30;

        public int[] RequiredExperiences => _requiredExperienceForLevel;
        [SerializeField] private int[] _requiredExperienceForLevel;


        public EnemyWaveDatas EnemyWaveDatas => _enemyWaveDatas;
        [SerializeField] private EnemyWaveDatas _enemyWaveDatas;


        public SkillData[] SkillDatas => _skillDatas;
        [SerializeField] private SkillData[] _skillDatas;
    }
}