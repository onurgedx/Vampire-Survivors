 
namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public interface ILevel
    {
        public int Number { get;  }
        public int CurrentExperience { get;}
        public int ExperienceCapacity { get; }
    }
}