using UnityEngine;
namespace VampireSurvivors.Gameplay.UI.Finish
{
    public class GameplayFinishFrameBehavior : VSBehavior
    {

        [SerializeField] private GameplayUIWinFrameBehavior _gameplayUIWinFrameBehavior;
        [SerializeField] private GameplayUILoseFrameBehavior _gameplayUILoseFrameBehavior;


        public void Init(GameplayFinishFrame a_gameplayFinishFrame)
        {
            _gameplayUILoseFrameBehavior.Init(a_gameplayFinishFrame.GameplayUILoseFrame);
            _gameplayUIWinFrameBehavior.Init(a_gameplayFinishFrame.GameplayUIWinFrame);
            a_gameplayFinishFrame.Showed += () => gameObject.SetActive(true);
        }


    }
}