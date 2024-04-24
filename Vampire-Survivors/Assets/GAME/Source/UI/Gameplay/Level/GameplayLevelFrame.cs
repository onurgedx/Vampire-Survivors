using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.UI.LevelSystem
{ 
    public class GameplayLevelFrame : IGameplayUILevel
    {
        public IActionProperty<int> Level => _level;
        private ActionProperty<int> _level;

        public IActionProperty<int> LevelManaCapacity => _levelManaCapacity;
        private ActionProperty<int> _levelManaCapacity;

        public IActionProperty<int> CurrentManaCount => _currentManaCount;
        private ActionProperty<int> _currentManaCount;

        public GameplayLevelFrame()
        {
            _level = new ActionProperty<int>(0);
            _levelManaCapacity = new ActionProperty<int>(0);
            _currentManaCount = new ActionProperty<int>(0);
        }

        public void UpdateLevel(int a_level)
        {
            _level.SetValue(a_level);
        }

        public void UpdateCurrentManaCount(int a_currentManaCount)
        {
            _currentManaCount.SetValue(a_currentManaCount);
        }

        public void UpdateLevelManaCapacity(int a_levelManaCapacity)
        {
            _levelManaCapacity.SetValue(a_levelManaCapacity);
        }
    }
}