using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Gameplay.UI.LevelSystem
{
    public class GameplayUILevelBehavior : VSBehavior
    {
        private IGameplayUILevel _gameplayUILevel;

        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private Slider _slider;
        public void Init(IGameplayUILevel a_gameplayUILevel)
        {
            _gameplayUILevel = a_gameplayUILevel;
            _gameplayUILevel.Level.RunOnChange(UpdateLevel);
            _gameplayUILevel.LevelManaCapacity.RunOnChange(UpdateLevelManaCapacity);
            _gameplayUILevel.CurrentManaCount.RunOnChange(UpdateManaCount);
        }

        private void UpdateLevel()
        {
            _levelText.text = "Level "+ _gameplayUILevel.Level.Value.ToString();
        }


        private void UpdateLevelManaCapacity()
        {
            _slider.maxValue = _gameplayUILevel.LevelManaCapacity.Value;
        }
        
        private void UpdateManaCount()
        {
            _slider.value = _gameplayUILevel.CurrentManaCount.Value;
        }

    }
}