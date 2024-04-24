using UnityEngine;
using VampireSurvivors.CameraSystems;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.UI.Menu;

namespace VampireSurvivors.Gameplay
{
    public class GameplaySceneEntry : SceneEntry
    {
        public static readonly string GameplaySystemScene = "GameplaySystem";
        public GameplaySystem GameplaySystem { get; private set; }
        [SerializeField] private LevelDatas _levelData;
        [SerializeField] private Transform _poolTransform;

        private VSSceneManager _vsSceneManager;


        public override void Load()
        {
            _vsSceneManager = new VSSceneManager( );
            LoadGameplayUI();
        }


        private void LoadGameplayUI()
        {
            ICompletable<GameplayUISceneEntry> gameplayUICompletable = _vsSceneManager.LoadAdditive<GameplayUISceneEntry>(GameplayUISceneEntry.GameplayUIScene);
            gameplayUICompletable.RunOnCompleted(() => CreateGameplaySystem(gameplayUICompletable.Value.GameplayUI));
        }


        private void CreateGameplaySystem(GameplayUI a_gameplayUI)
        {
            GameplaySystem = new GameplaySystem(_levelData, a_gameplayUI, _poolTransform);
            LoadCamera();
            a_gameplayUI.GameplayFinishFrame.GameplayUILoseFrame.BackToMenuButton += BackToMenu;
            a_gameplayUI.GameplayFinishFrame.GameplayUIWinFrame.BackToMenuButton += BackToMenu;
        }


        private void LoadCamera()
        {
            ICompletable<CameraSceneEntry> cameraSceneEntry = _vsSceneManager.LoadAdditive<CameraSceneEntry>(CameraSceneEntry.SceneName);
            cameraSceneEntry.RunOnCompleted(() =>
            {
                cameraSceneEntry.Value.VSCamera.Init(GameplaySystem.PlayerControlSystem.Position);
            });
        }


        private void BackToMenu()
        {
            _vsSceneManager.LoadAdditive<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI).RunOnCompleted(UnloadRelatedScenes); 
        }


        private void UnloadRelatedScenes()
        {
            _vsSceneManager.Unload<GameplaySceneEntry>(GameplaySystemScene);
            _vsSceneManager.Unload<CameraSceneEntry>(CameraSceneEntry.SceneName);
            _vsSceneManager.Unload<GameplayUISceneEntry>(GameplayUISceneEntry.GameplayUIScene);
        }


        public override void Unload()
        { 
        }


        private void Update()
        {
            GameplaySystem?.Update();
        }
    }
}