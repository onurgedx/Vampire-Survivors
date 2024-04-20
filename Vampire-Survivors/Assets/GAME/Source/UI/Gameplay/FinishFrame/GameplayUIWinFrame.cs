
using System;

namespace VampireSurvivors.Gameplay.UI.Finish
{
    
    public class GameplayUIWinFrame  
    {
        public Action Showed;
        public Action Hided;
        public Action BackToMenuButton;


        public GameplayUIWinFrame()
        {
        }

        public void Show()
        {
            Showed?.Invoke();
        }

        public void Hide()
        {
            Hided?.Invoke();
        }

        public void BackToMenu()
        {
            BackToMenuButton?.Invoke();
        }
    }
}