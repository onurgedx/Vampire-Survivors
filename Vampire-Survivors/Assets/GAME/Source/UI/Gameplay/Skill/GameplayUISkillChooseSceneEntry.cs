using UnityEngine; 
namespace VampireSurvivors.Gameplay.UI.SkillSystem
{
    public class GameplayUISkillChooseSceneEntry : SceneEntry
    {
        public static readonly string SceneName = "UI.Gameplay.SkillChoose";
        [SerializeField] private SkillChooseFrameBehavior _skillChooseFrameBehavior;
        public SkillChooseFrame SkillChooseFrame { get; private set; }
        public override void Load()
        {
            SkillChooseFrame = new SkillChooseFrame();
            _skillChooseFrameBehavior.Init( SkillChooseFrame); 
        }
    }
}