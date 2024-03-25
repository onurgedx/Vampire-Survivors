namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public class Level : ILevel
    {

        public int Number { get;  set; }
        public Experience CurrentExperience { get;  set; }
        public Experience ExperienceCapacity { get;  set; }


        public Level(Experience a_experienceCapacity )
        {
            Number = 0;
            CurrentExperience = 0;
            ExperienceCapacity = a_experienceCapacity;
        }    

        
        public void Reset(int a_levelNumber, Experience a_manaCapacity )
        {
            Number = a_levelNumber;
            ExperienceCapacity = a_manaCapacity;
            CurrentExperience = Experience.Zero;
        }                
    }
}