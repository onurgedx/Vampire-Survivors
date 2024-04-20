
using System;

namespace VampireSurvivors.Gameplay.UI.Finish
{
    public class GameplayFinishFrame  
    {
        public GameplayUIWinFrame GameplayUIWinFrame { get; private set; }
        public GameplayUILoseFrame GameplayUILoseFrame { get; private set; }
        public Action Showed;

        public GameplayFinishFrame()
        {
            GameplayUIWinFrame = new GameplayUIWinFrame();
            GameplayUILoseFrame = new GameplayUILoseFrame();
        }

        public void Win()
        {
            Showed?.Invoke();
            GameplayUIWinFrame.Show();
        }

        public void Lose()
        {
            Showed?.Invoke();
            GameplayUILoseFrame.Show();
        }



    }
}