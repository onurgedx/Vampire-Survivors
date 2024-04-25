 

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    /// <summary>
    /// Ensures SkillImprovments correctly complete
    /// </summary>
    public abstract class SkillImproveHelper
    {
        public abstract void Improve(SkillImprovement a_skillImprovement, Skill a_skill);

    }

    public class CooldownDecreaser : SkillImproveHelper
    {
        public override void Improve(SkillImprovement a_skillImprovement, Skill a_skill)
        {
            if (a_skillImprovement is CooldownDecreaseFeature cooldownDecrease)
            {
                a_skill.Cooldown =a_skill.Cooldown  * ((100 - cooldownDecrease.CooldownDecreaseRate) * 0.01f);
            }
        }
    }


    public class DamageIncreaser : SkillImproveHelper
    {
        public override void Improve(SkillImprovement a_skillImprovement, Skill a_skill)
        {
            if (a_skillImprovement is DamageIncreaseFeature damageIncrease)
            {
                a_skill.Damage =(int)( a_skill.Damage * ((100 + damageIncrease.DamageIncreaseRate) * 0.01f))+1;
            }
        }
    }


    public class CountIncreaser : SkillImproveHelper
    {
        public override void Improve(SkillImprovement a_skillImprovement, Skill a_skill)
        {
            if (a_skillImprovement is CountIncreaseFeature countIncrease)
            {
                a_skill.Count +=  countIncrease.IncreaseCount ;
            }
        }
    }

    public class SizeIncreaser : SkillImproveHelper
    {
        public override void Improve(SkillImprovement a_skillImprovement, Skill a_skill)
        { 
            if(a_skillImprovement is SizeIncreaseFeature sizeIncrease)
            {
                a_skill.Size *= (100 + sizeIncrease.SizeIncreaseRate) * 0.01f;
            }
        }
    }
}