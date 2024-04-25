
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    /// <summary>
    /// Controls Skill
    /// </summary>
    public abstract class SkillController
    {
        /// <summary>
        /// Level UP Skill
        /// </summary>
        /// <param name="a_skillImprovments"></param>
        public abstract void LevelUp(SkillImprovement[] a_skillImprovments);
    }
}