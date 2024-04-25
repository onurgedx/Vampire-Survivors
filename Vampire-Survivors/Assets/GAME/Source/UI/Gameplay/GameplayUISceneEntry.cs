using UnityEngine;
using VampireSurvivors.Gameplay.UI.Finish;
using VampireSurvivors.Gameplay.UI.GameTime;
using VampireSurvivors.Gameplay.UI.LevelSystem;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.UI.SkillSystem;

namespace VampireSurvivors.Gameplay.UI
{
    public class GameplayUISceneEntry : SceneEntry
    {
        public static readonly string GameplayUIScene = "UI.Gameplay";

        public GameplayUI GameplayUI { get; private set; }

        [SerializeField] private GameObject[] _hideOnUnloadGameobjects = new GameObject[] { };
        [SerializeField] private SkillChooseFrameBehavior _skillChooseFrameBehavior;
        [SerializeField] private GameplayUILevelBehavior _gameplayUILevelBehavior;
        [SerializeField] private PlayerHPFrameBehavior _playerHPFrameBehavior;
        [SerializeField] private GameplayFinishFrameBehavior _gameplayFinishFrameBehavior;
        [SerializeField] private TimeFrameBehavior _timeFrameBehavior;


        public override void Load()
        {
            GameplayUI = new GameplayUI();
            _skillChooseFrameBehavior.Init(GameplayUI.SkillChooseFrame);
            _gameplayUILevelBehavior.Init(GameplayUI.GameplayUILevel);
            _playerHPFrameBehavior.Init(GameplayUI.PlayerHPFrame);
            _gameplayFinishFrameBehavior.Init(GameplayUI.GameplayFinishFrame);
            _timeFrameBehavior.Init(GameplayUI.TimeFrame);
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