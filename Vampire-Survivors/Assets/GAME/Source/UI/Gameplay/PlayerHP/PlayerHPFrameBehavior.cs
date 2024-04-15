using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Gameplay.UI.PlayerHP
{
    public class PlayerHPFrameBehavior : VSBehavior
    {
        private IPlayerHPFrame _playerHPFrame;
        [SerializeField] private Slider _hpSlider;

        public void Init(IPlayerHPFrame a_playerHPFrame)
        {
            _playerHPFrame = a_playerHPFrame;
            _playerHPFrame.CurrentHP.RunOnChange(UpdateCurrentHP);
            _playerHPFrame.MaxHP.RunOnChange(UpdateMaxHP);

        }

        private void UpdateCurrentHP()
        {
            _hpSlider.value= _playerHPFrame.CurrentHP.Value;
        }


        private void UpdateMaxHP()
        {
            _hpSlider.maxValue = _playerHPFrame.MaxHP.Value;
        }
    }
}