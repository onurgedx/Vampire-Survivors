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
            gameplayUICompletable.Completed += () => GameplayUILoaded(gameplayUICompletable.Value);
        }


        private void GameplayUILoaded(GameplayUISceneEntry gameplayUISceneEntry)
        {
            LoadGameplaySystem(gameplayUISceneEntry.GameplayUI);
        }


        private void LoadGameplaySystem(GameplayUI a_gameplayUI)
        {
            Completable<GameplaySceneEntry> gameplaySceneEntry = _vsSceneManager.LoadAdditive<GameplaySceneEntry>(GameplaySceneEntry.GameplaySystemScene);
            gameplaySceneEntry.Completed += () => GameplaySystemLoaded(a_gameplayUI, gameplaySceneEntry.Value);
        }


        private void GameplaySystemLoaded(GameplayUI a_gameplayUI, GameplaySceneEntry a_gameplaySystemSceneEntry)
        {
            a_gameplaySystemSceneEntry.GameplaySystem.SkillSystem.SkillRequested += a_gameplayUI.SkillChooseFrame.ActivateChooseSkill;
            a_gameplayUI.SkillChooseFrame.SkillChooseDeactivate += a_gameplaySystemSceneEntry.GameplaySystem.ContinueGame;

            LoadCameraSystem(a_gameplaySystemSceneEntry.GameplaySystem);
        }


        private void LoadCameraSystem(GameplaySystem a_gameplaySystem)
        {
            Completable<CameraSceneEntry> cameraSceneEntry = _vsSceneManager.LoadAdditive<CameraSceneEntry>(CameraSceneEntry.SceneName);
            cameraSceneEntry.Completed += () => cameraSceneEntry.Value.VSCamera.Init(a_gameplaySystem.PlayerControlSystem.Position);
        }
    }
}
