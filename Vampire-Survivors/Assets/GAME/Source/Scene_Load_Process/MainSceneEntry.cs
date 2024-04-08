using VampireSurvivors.CameraSystems;
using VampireSurvivors.Gameplay;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.UI;
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
            uiMenuCompletable.Completed += () => MenuUILoaded(uiMenuCompletable.Value);
        }


        private void MenuUILoaded(UIMenuSceneEntry uiMenuSceneEntry)
        {
            uiMenuSceneEntry.MenuUIFrame.StartGame += LoadGameplayUI;
        }


        private void LoadGameplayUI()
        {
            _vsSceneManager.Unload<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI);
            Completable<GameplayUISceneEntry> gameplayUICompletable = _vsSceneManager.LoadAdditive<GameplayUISceneEntry>(GameplayUISceneEntry.GameplayUIScene);
            gameplayUICompletable.Completed += () => GameplayUILoaded( );
        }


        private void GameplayUILoaded( )
        {
            LoadGameplaySystem( );
        }


        private void LoadGameplaySystem( )
        {
            Completable<GameplaySceneEntry> gameplaySceneEntry = _vsSceneManager.LoadAdditive<GameplaySceneEntry>(GameplaySceneEntry.GameplaySystemScene);
            gameplaySceneEntry.Completed += () => GameplaySystemLoaded( gameplaySceneEntry.Value);
        }


        private void GameplaySystemLoaded( GameplaySceneEntry a_gameplaySystemSceneEntry)
        {  
            LoadCameraSystem(a_gameplaySystemSceneEntry.GameplaySystem);
        }


        private void LoadCameraSystem(GameplaySystem a_gameplaySystem)
        {
            Completable<CameraSceneEntry> cameraSceneEntry = _vsSceneManager.LoadAdditive<CameraSceneEntry>(CameraSceneEntry.SceneName);
            cameraSceneEntry.Completed += () => cameraSceneEntry.Value.VSCamera.Init(a_gameplaySystem.PlayerControlSystem.Position);
        }
    }
}
