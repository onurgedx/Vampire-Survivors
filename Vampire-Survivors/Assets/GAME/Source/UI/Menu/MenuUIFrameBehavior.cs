
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI.Menu
{
    public class MenuUIFrameBehavior : VSBehavior
    {


        [SerializeField] private Button _startButton;

        public void Init(MenuUIFrame a_menuUIFrame)
        {
            _startButton.onClick.AddListener(a_menuUIFrame.StartButtonClicked);
        }
        

    }
}