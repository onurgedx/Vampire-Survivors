
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class ActiveSkillFactory : SkillFactory<SkillBeginingData>
    {
        public override Skill CrateSkill(SkillBeginingData a_arg)
        {
            if (a_arg is ActiveSkillBeginningData activeArg)
            {
                return new Skill(activeArg.Cooldown, activeArg.Duration, activeArg.Damage, activeArg.Size, activeArg.Count);

            }
            Debug.LogError("Data Parameter is not right!");
            return new Skill(1, 1, 1, 1, 1);
        }
    }
}