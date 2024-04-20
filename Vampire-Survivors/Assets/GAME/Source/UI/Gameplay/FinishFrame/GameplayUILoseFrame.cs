
using System;

namespace VampireSurvivors.Gameplay.UI.Finish
{
    public class GameplayUILoseFrame 
    {
        public Action Showed;
        public Action Hided;
        public Action BackToMenuButton;


        public GameplayUILoseFrame()
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