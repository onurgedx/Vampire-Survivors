 
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(menuName = "Data/SkillData", fileName = "Skill", order = 0)]
    public class SkillDatas : ScriptableObject
    {
        public SkillData[] Datas => _skillDatas;
            
        [SerializeField] private SkillData[] _skillDatas;


    }
}