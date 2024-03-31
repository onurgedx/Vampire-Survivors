using System;

namespace VampireSurvivors.UI.Menu
{
    public class MenuUIFrame
    {
        public Action StartGame;

        public MenuUIFrame()
        {
        }


        public void StartButtonClicked()
        {
            StartGame?.Invoke();
        }
    }
}