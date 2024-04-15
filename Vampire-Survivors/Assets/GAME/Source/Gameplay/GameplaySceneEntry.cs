using UnityEngine;
using VampireSurvivors.CameraSystems;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Lib.Basic.Completables;

namespace VampireSurvivors.Gameplay
{
    public class GameplaySceneEntry : SceneEntry
    {
        public static readonly string GameplaySystemScene = "GameplaySystem";
        public GameplaySystem GameplaySystem { get; private set; }
        [SerializeField] private LevelDatas _levelData;

        private VSSceneManager _vsSceneManager; 

        public override void Load()
        {
            _vsSceneManager = new VSSceneManager();
            ICompletable<GameplayUISceneEntry> gameplayUICompletable = _vsSceneManager.LoadAdditive<GameplayUISceneEntry>(GameplayUISceneEntry.GameplayUIScene);
            gameplayUICompletable.RunOnCompleted(() => CreateGameplaySystem(gameplayUICompletable.Value.GameplayUI));
        }

        private void CreateGameplaySystem(GameplayUI a_gameplayUI)
        {
            GameplaySystem = new GameplaySystem(_levelData, a_gameplayUI);
            LoadCamera();
        }

        private void LoadCamera()
        {
            ICompletable<CameraSceneEntry> cameraSceneEntry = _vsSceneManager.LoadAdditive<CameraSceneEntry>(CameraSceneEntry.SceneName);
            cameraSceneEntry.RunOnCompleted(() =>
            {
                cameraSceneEntry.Value.VSCamera.Init(GameplaySystem.PlayerControlSystem.Position);
            });
        }

        public override void Unload()
        {

            base.Unload();
            GameplaySystem.Unload();
        }


        private void Update()
        {
            GameplaySystem?.Update();
        }


    }
}