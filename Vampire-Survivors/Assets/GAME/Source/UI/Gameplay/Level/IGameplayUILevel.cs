 
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.UI.LevelSystem
{
    public interface IGameplayUILevel
    {
        public IActionProperty<int> Level { get; }
        public IActionProperty<int> LevelManaCapacity { get; }
        public IActionProperty<int> CurrentManaCount { get; }
    }
}