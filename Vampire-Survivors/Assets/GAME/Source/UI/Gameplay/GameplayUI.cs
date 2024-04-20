
using VampireSurvivors.Gameplay.UI.Finish;
using VampireSurvivors.Gameplay.UI.GameTime;
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
        public GameplayFinishFrame GameplayFinishFrame { get;private set;}
        public TimeFrame TimeFrame { get; private set; }

        public GameplayUI()
        {
            GameplayUILevel = new GameplayLevelFrame();
            SkillChooseFrame = new SkillChooseFrame();
            PlayerHPFrame = new PlayerHPFrame();
            GameplayFinishFrame = new GameplayFinishFrame();
            TimeFrame = new TimeFrame();
        }
         
    }

}