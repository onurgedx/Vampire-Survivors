using VampireSurvivors.CameraSystems;
using VampireSurvivors.Gameplay;
using VampireSurvivors.Gameplay.Systems; 
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.UI.Menu;

namespace VampireSurvivors.SceneProcess
{
    /// <summary>
    /// 
    /// </summary>
    public class MainSceneEntry : VSBehavior
    { 
        private VSSceneManager _vsSceneManager;


        public void Start()
        {
            _vsSceneManager = new VSSceneManager();
            LoadMenuUI();
        }


        private void LoadMenuUI()
        {
            Completable<UIMenuSceneEntry> uiMenuCompletable = _vsSceneManager.LoadAdditive<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI);
            uiMenuCompletable.RunOnCompleted(() => MenuUILoaded(uiMenuCompletable.Value));
        }


        private void MenuUILoaded(UIMenuSceneEntry uiMenuSceneEntry)
        {
            uiMenuSceneEntry.MenuUIFrame.StartGame += LoadGameplaySystem;
        } 
        

        private void LoadGameplaySystem( )
        {   
            _vsSceneManager.Unload<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI);
            Completable<GameplaySceneEntry> gameplaySceneEntry = _vsSceneManager.LoadAdditive<GameplaySceneEntry>(GameplaySceneEntry.GameplaySystemScene);             
        }


         
    }
}
