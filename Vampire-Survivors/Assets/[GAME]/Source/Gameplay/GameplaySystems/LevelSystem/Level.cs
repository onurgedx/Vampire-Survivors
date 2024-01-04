using System;

namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public class Level : ILevel
    {

        public int Number { get;  set; }
        public int CurrentExperience { get;  set; }
        public int ExperienceCapacity { get;  set; }


        public Level(int a_experienceCapacity =10)
        {
            Number = 0;
            CurrentExperience = 0;
            ExperienceCapacity = a_experienceCapacity;
        }    

        
        public void Reset(int a_levelNumber, int a_manaCapacity )
        {
            Number = a_levelNumber;
            ExperienceCapacity = a_manaCapacity;
            CurrentExperience = 0;
        }
                
    }
}