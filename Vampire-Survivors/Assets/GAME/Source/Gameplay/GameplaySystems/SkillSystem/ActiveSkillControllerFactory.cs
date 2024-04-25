namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class ActiveSkillControllerFactory : SkillControllerFactory
    {
        protected ActiveSkillFactory _skillFactory;

        protected ActiveSkillControllerFactory( ActiveSkillFactory a_skillFactory )
        {
            _skillFactory = a_skillFactory;
        }


    }
}