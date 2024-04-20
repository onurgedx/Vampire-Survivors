
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillControllerFactory
    {

        public abstract SkillController Create(Skill a_skill, int a_skillLevelHash);


         
    }
}