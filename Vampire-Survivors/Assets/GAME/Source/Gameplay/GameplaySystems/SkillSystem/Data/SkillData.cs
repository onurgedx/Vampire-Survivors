using System;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "SkillData", menuName = "Data/Skills/SkillData", order = 1)]
    [Serializable]
    public class SkillData: ScriptableObject
    {
        public string Name => this.name;
        public SkillLevel[]  Levels => _skillLevels;

        [SerializeField] private SkillLevel[] _skillLevels;
        
         

    }
}