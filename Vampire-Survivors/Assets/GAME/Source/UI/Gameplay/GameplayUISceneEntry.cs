using UnityEngine;
using VampireSurvivors.Gameplay.UI.Finish;
using VampireSurvivors.Gameplay.UI.LevelSystem;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.UI.SkillSystem;

namespace VampireSurvivors.Gameplay.UI
{
    public class GameplayUISceneEntry : SceneEntry
    {
        public static readonly string GameplayUIScene = "UI.Gameplay";

        [SerializeField] private GameObject[] _hideOnUnloadGameobjects = new GameObject[] { };
        public GameplayUI GameplayUI { get; private set; }
        [SerializeField] private SkillChooseFrameBehavior _skillChooseFrameBehavior;

        [SerializeField] private GameplayUILevelBehavior _gameplayUILevelBehavior;
        [SerializeField] private PlayerHPFrameBehavior _playerHPFrameBehavior;
        [SerializeField] private GameplayFinishFrameBehavior _gameplayFinishFrameBehavior;
        public override void Load()
        {
            GameplayUI = new GameplayUI();
            _skillChooseFrameBehavior.Init(GameplayUI.SkillChooseFrame);
            _gameplayUILevelBehavior.Init(GameplayUI.GameplayUILevel);
            _playerHPFrameBehavior.Init(GameplayUI.PlayerHPFrame);
            _gameplayFinishFrameBehavior.Init(GameplayUI.GameplayFinishFrame);
        }

        public override void Unload()
        {
            foreach (GameObject go in _hideOnUnloadGameobjects)
            {
                go.SetActive(false);
            }
        }
    }
}