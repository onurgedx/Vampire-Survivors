using System;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    public class LevelSystem : VSSystem, IExperiencer
    {
        public Action LevelUp;
        public Action Experienced;

        public ILevel Level => _level;
        private Level _level;
        private int[] _levelCapaties = new int[] { };


        public LevelSystem(LevelDatas a_levelData)
        {
            _levelCapaties = a_levelData.RequiredExperiences;
            _level = new Level(new Experience(_levelCapaties[0]));
        }


        public void ExperienceGained(Experience a_exp)
        {
            Experience experienceSum = (_level.CurrentExperience + a_exp);
            Experience extraExperience = experienceSum - _level.ExperienceCapacity;
            if (extraExperience.Value >= 0)
            {
                UpdateLevel();
                ExperienceGained(extraExperience);
            }
            else
            {
                UpdateExperience(experienceSum);
            }
            Debug.Log(_level.Number);
        }


        private void UpdateLevel()
        {
            _level.Number = _level.Number + 1;
            _level.ExperienceCapacity = RequiredExperience(_level.Number);
            _level.CurrentExperience = 0;
            LevelUp?.Invoke();
        }


        private void UpdateExperience(Experience a_experience)
        {
            _level.CurrentExperience = a_experience;
            Experienced?.Invoke();
        }


        private int RequiredExperience(int a_levelNumber)
        {
            if (a_levelNumber >=_levelCapaties.Length )
            {
                return _levelCapaties[^-1];
            }
            return _levelCapaties[a_levelNumber];
        }
    }
}