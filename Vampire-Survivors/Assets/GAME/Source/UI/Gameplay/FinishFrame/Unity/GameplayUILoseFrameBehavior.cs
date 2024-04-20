
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Gameplay.UI.Finish
{
    public class GameplayUILoseFrameBehavior : VSBehavior
    {
        [SerializeField] private Button _backToMenuButton;
        public void Init(GameplayUILoseFrame a_gameplayUILoseFrame)
        {
            _backToMenuButton.onClick.AddListener(a_gameplayUILoseFrame.BackToMenu);
            a_gameplayUILoseFrame.Showed += () => { gameObject.SetActive(true); };
            a_gameplayUILoseFrame.Hided += () => { gameObject.SetActive(false); };
        }

    }
}