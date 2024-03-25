 
namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public interface ILevel
    {
        public int Number { get;  }
        public Experience CurrentExperience { get;}
        public Experience ExperienceCapacity { get; }
    }
}