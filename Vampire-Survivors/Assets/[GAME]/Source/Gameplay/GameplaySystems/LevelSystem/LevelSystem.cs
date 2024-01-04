using System;
namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public class LevelSystem : VSSystem
    {
        public Action LevelUp;
        public Action Experienced;

        public ILevel Level => _level;
        private Level _level;
        private int[] _levelCapaties = new int[] { };


        public LevelSystem(LevelDatas a_levelData)
        {
            _levelCapaties = a_levelData.RequiredExperiences;
            _level = new Level(_levelCapaties[0]);
        }


        public void ExperienceGained(int a_exp)
        {
            int experienceSum = (_level.CurrentExperience + a_exp);
            int extraExperience = experienceSum - _level.ExperienceCapacity;
            if (extraExperience >= 0)
            {
                UpdateLevel();
                ExperienceGained(extraExperience);
            }
            else
            {
                UpdateExperience(experienceSum);
            }
        }


        private void UpdateLevel()
        {
            _level.Number = _level.Number + 1;
            _level.ExperienceCapacity = RequiredExperience(_level.Number);
            _level.CurrentExperience = 0;
            LevelUp?.Invoke();
        }


        private void UpdateExperience(int a_experience)
        {
            _level.CurrentExperience = a_experience;
            Experienced?.Invoke();
        }


        private int RequiredExperience(int a_levelNumber)
        {
            if (_levelCapaties.Length > a_levelNumber)
            {
                return _levelCapaties[^-1];
            }
            return _levelCapaties[a_levelNumber];
        }
    }
}