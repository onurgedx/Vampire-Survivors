
using UnityEngine; 

namespace VampireSurvivors.Gameplay.UI
{
    public class GameplayUISceneEntry : SceneEntry
    {


        public static readonly string GameplayUIScene = "UI.Gameplay";

        [SerializeField] private SkillChooseFrameBehavior _skillChooseFrameBehavior;

        public GameplayUI GameplayUI { get; private set; }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }

        public override void Load()
        {
            GameplayUI = new GameplayUI();
            _skillChooseFrameBehavior.Init(GameplayUI.SkillChooseFrame);

        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }
    }   
}