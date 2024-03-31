using UnityEngine;

namespace VampireSurvivors.UI.Menu
{
    public class UIMenuSceneEntry : SceneEntry
    {
        public static readonly string Scene_MenuUI = "UI.Menu";

        public MenuUIFrame MenuUIFrame { get; private set; }

        [SerializeField] private MenuUIFrameBehavior _menuUIFrameBehavior;



        public override void Load()
        {
            MenuUIFrame = new MenuUIFrame();
            _menuUIFrameBehavior.Init(MenuUIFrame);
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}