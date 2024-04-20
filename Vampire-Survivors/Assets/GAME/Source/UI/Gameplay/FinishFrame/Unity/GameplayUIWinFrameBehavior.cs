
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Gameplay.UI.Finish
{
    public class GameplayUIWinFrameBehavior : VSBehavior
    {
        [SerializeField] private Button _backToMenuButton;

        public void Init(GameplayUIWinFrame a_gameplayUIWinFrame)
        {
            _backToMenuButton.onClick.AddListener(a_gameplayUIWinFrame.BackToMenu);
            a_gameplayUIWinFrame.Showed += ()=> { gameObject.SetActive(true); };
            a_gameplayUIWinFrame.Hided += ()=> { gameObject.SetActive(false); };
        }


    }
}