using UnityEngine;
using VampireSurvivors.Gameplay.UI.LevelSystem;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.UI.SkillSystem;

namespace VampireSurvivors.Gameplay.UI
{
    public class GameplayUISceneEntry : SceneEntry
    {
        public static readonly string GameplayUIScene = "UI.Gameplay";

        public GameplayUI GameplayUI { get; private set; }
        [SerializeField] private SkillChooseFrameBehavior _skillChooseFrameBehavior;

        [SerializeField] private GameplayUILevelBehavior _gameplayUILevelBehavior;
        [SerializeField] private PlayerHPFrameBehavior _playerHPFrameBehavior;

        public override void Load()
        {
            GameplayUI = new GameplayUI();
            _skillChooseFrameBehavior.Init(GameplayUI.SkillChooseFrame);
            _gameplayUILevelBehavior.Init(GameplayUI.GameplayUILevel);
            _playerHPFrameBehavior.Init(GameplayUI.PlayerHPFrame);
        }
    }
}