using UnityEngine;
using VampireSurvivors.Gameplay; 

namespace VampireSurvivors.UI.Menu
{
    public class UIMenuSceneEntry : SceneEntry
    {
        public static readonly string Scene_MenuUI = "UI.Menu";

        public MenuUIFrame MenuUIFrame { get; private set; }

        [SerializeField] private MenuUIFrameBehavior _menuUIFrameBehavior;
        [SerializeField] private GameObject[] _hideOnUnloadGameobjects= new GameObject[] { };

        private VSSceneManager _vsSceneManager;


        public override void Load()
        {
            _vsSceneManager = new VSSceneManager();
            MenuUIFrame = new MenuUIFrame();
            _menuUIFrameBehavior.Init(MenuUIFrame);
            MenuUIFrame.StartGame += LoadGameplaySystem;
        }


        private void LoadGameplaySystem()
        {
            _vsSceneManager.LoadAdditive<GameplaySceneEntry>(GameplaySceneEntry.GameplaySystemScene).RunOnCompleted(UnloadThisScene); 
        }


        private void UnloadThisScene()
        {
            _vsSceneManager.Unload<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI);
        }


        public override void Unload()
        {
            foreach (GameObject go  in _hideOnUnloadGameobjects)
            {
                go.SetActive(false);
            }
        }


    }
}