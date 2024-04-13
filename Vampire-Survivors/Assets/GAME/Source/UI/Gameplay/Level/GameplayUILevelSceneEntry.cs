using UnityEngine;

namespace VampireSurvivors.Gameplay.UI.LevelSystem
{
    public class GameplayUILevelSceneEntry : SceneEntry
    {
        public static readonly string SceneName = "UI.Gameplay.Level";

       [SerializeField]  private GameplayUILevelBehavior _gameplayUILevelBehavior;
        public GameplayUILevel GameplayUILevel { get; private set; }

        public override void Load()
        {
            GameplayUILevel = new GameplayUILevel();
            _gameplayUILevelBehavior.Init(GameplayUILevel);
        }
    }
}