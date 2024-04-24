using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "SkillLevelImprovements", menuName = "Data/Skills/SkillLevelImprovements", order = 1)]     
    public class SkillLevelImprovements : ScriptableObject
    {
        public SkillImprovement[] Improvements => LevelImprovments;
        [SerializeField] private SkillImprovement[] LevelImprovments = new SkillImprovement[] { };        
    }
}