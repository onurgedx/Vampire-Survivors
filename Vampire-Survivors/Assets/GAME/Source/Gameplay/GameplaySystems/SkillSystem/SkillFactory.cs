namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillFactory<T>
    {
        public abstract Skill CrateSkill(T a_arg);
    }
}