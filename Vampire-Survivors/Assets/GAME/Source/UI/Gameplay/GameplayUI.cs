
using VampireSurvivors.Gameplay.UI.LevelSystem;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.UI.SkillSystem;

namespace VampireSurvivors.Gameplay.UI
{


    public class GameplayUI
    {
        public GameplayLevelFrame GameplayUILevel { get; private set; }
        public SkillChooseFrame SkillChooseFrame { get; private set; }

        public PlayerHPFrame PlayerHPFrame { get; private set; }

        public GameplayUI()
        {
            GameplayUILevel = new GameplayLevelFrame();
            SkillChooseFrame = new SkillChooseFrame();
            PlayerHPFrame = new PlayerHPFrame();
        }
    }

}