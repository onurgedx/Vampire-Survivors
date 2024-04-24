
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillController
    {
        public ISkill Skill => _skill;
        protected Skill _skill { get; set; }

        public abstract void LevelUp(SkillImprovement[] a_skillImprovments);
    }
}