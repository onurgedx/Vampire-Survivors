
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    [CreateAssetMenu(fileName = "PassiveSkillBeginningData", menuName = "Data/Skills/BegginingDatas/PassiveSkillBeginningData", order = 1)]
    public class PassiveSkillBeginningData : SkillBeginingData
    {
        public int IncreaseAmount => _increaseAmount;
        [SerializeField] private int _increaseAmount=15;

    }
}