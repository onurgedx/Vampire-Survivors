using System; 
using VampireSurvivors.Gameplay.Systems.SkillSys;
using VampireSurvivors.Gameplay.UI.LevelSystem; 

namespace VampireSurvivors.Gameplay.Systems.LevelSys
{
    /// <summary>
    /// Controls Player's Level 
    /// </summary>
    public class LevelSystem : VSSystem, IExperiencer
    {
        public Action LevelUp;
        public Action Experienced;

        public ILevel Level => _level;
        private Level _level;
        private int[] _levelCapaties = new int[] { };

        private ISkillRequester _skillRequester; 
        private GameplayLevelFrame _gameplayUILevel;

        public LevelSystem(int[] a_levelCapaties, ISkillRequester a_skillRequester, GameplayLevelFrame a_gameplayLevelUI)
        {
            _skillRequester = a_skillRequester;
            _levelCapaties = a_levelCapaties;
            _level = new Level(new Experience(_levelCapaties[0]));
            _gameplayUILevel = a_gameplayLevelUI;

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
                _gameplayUILevel.UpdateCurrentManaCount(_level.CurrentExperience.Value);
            }
        }


        private void UpdateLevel()
        {
            _level.Number = _level.Number + 1;
            _level.ExperienceCapacity = RequiredExperience(_level.Number);
            _level.CurrentExperience = 0;
            _skillRequester.RequestSkill();
            LevelUp?.Invoke();
            _gameplayUILevel.UpdateLevel(_level.Number);
            _gameplayUILevel.UpdateLevelManaCapacity(_level.ExperienceCapacity.Value);
        }


        private void UpdateExperience(Experience a_experience)
        {
            _level.CurrentExperience = a_experience;
            Experienced?.Invoke();
        }


        private int RequiredExperience(int a_levelNumber)
        {
            if (a_levelNumber >= _levelCapaties.Length)
            {
                return _levelCapaties[^-1];
            }
            return _levelCapaties[a_levelNumber];
        }
    }
}