using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.ChestSys;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Systems.HealSys;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Gameplay.Systems.ManaSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Systems.SkillSys;
using VampireSurvivors.Gameplay.UI;

namespace VampireSurvivors.Gameplay.Systems
{
    public class GameplaySystem : VSSystem
    {

        public SkillSystem SkillSystem { get; private set; }
        public CraftingSystem CraftingSystem{ get; private set; }
        public PlayerControlSystem PlayerControlSystem { get; private set; }
        public AIControlSystem AIControlSystem { get; private set; }        
        public CollectionSystem CollectionSystem { get; private set; }
        public ManaSystem ManaSystem { get; private set; }
        public HealSystem HealSystem { get; private set; }
        public ChestSystem ChestSystem { get; private set; }
        public BattleSystem BattleSystem { get; private set; }
        public LevelSystem LevelSystem { get; private set; }
         
        private LevelDatas _levelData;

        private bool _paused = false;


        public GameplaySystem(LevelDatas a_levelDatas ,GameplayUI a_gameplayUI  , Transform a_poolTransform)
        {
            _levelData = a_levelDatas; 

            PlayerControlSystem = new PlayerControlSystem( );

            SetupBattleSystem();

            AIControlSystem = new AIControlSystem(PlayerControlSystem.Position);
            SetupCraftingSystem(a_gameplayUI);
            SetupSkillSystem(a_gameplayUI);

            LevelSystem = new LevelSystem(_levelData.RequiredExperiences, SkillSystem, a_gameplayUI.GameplayUILevel);

            CollectionSystem = new CollectionSystem();
            ChestSystem = new ChestSystem(CollectionSystem.CollectableRecorder,
                                          CollectionSystem.CollectorAdder,
                                          PlayerControlSystem.Position,
                                          a_poolTransform,
                                          SkillSystem);
            ManaSystem = new ManaSystem(CollectionSystem.CollectableRecorder,
                                        CollectionSystem.CollectorAdder,
                                        PlayerControlSystem.Position,
                                        a_poolTransform,
                                        LevelSystem);
            HealSystem = new HealSystem(CollectionSystem.CollectableRecorder,
                                        CollectionSystem.CollectorAdder,
                                        PlayerControlSystem.Position,
                                        a_poolTransform,
                                        CraftingSystem.PlayerUnitHealth);
        }


        private void SetupBattleSystem()
        {
            BattleSystem = new BattleSystem(PlayerControlSystem.Position);
            BattleSystem.PlayerDead += LoseGame;
        }


        private void SetupSkillSystem(GameplayUI a_gameplayUI)
        {
            SkillSystem = new SkillSystem(PlayerControlSystem.Position, PlayerControlSystem.Direction, a_gameplayUI.SkillChooseFrame);
            SkillSystem.DamageRequest += BattleSystem.Damage;
            SkillSystem.SkillRequested += PauseGame;
            SkillSystem.SkillChoosed += ContinueGame;
        }


        private void SetupCraftingSystem(GameplayUI a_gameplayUI)
        {
            CraftingSystem = new CraftingSystem(PlayerControlSystem,
                                                AIControlSystem.EnemyMovementControl,
                                                BattleSystem.DamageRecorder,
                                                a_gameplayUI.PlayerHPFrame,
                                                BattleSystem.GameObjectDamageSourceTypeRecorder,
                                                _levelData.EnemyWaveDatas);
        }
               

        public override void Update()
        {
            if(_paused) { return; }
            base.Update();
            PlayerControlSystem.Update();
            AIControlSystem.Update();
            ChestSystem.Update();
            ManaSystem.Update();
            HealSystem.Update();
            CollectionSystem.Update();
            CraftingSystem.Update();
            SkillSystem.Update();
            BattleSystem.Update();
        }


        private void PauseGame()
        {
            _paused = true;
        }


        public void ContinueGame()
        {
            _paused = false;
        }


        public void WinGame()
        {

        }


        public void LoseGame()
        {
            Debug.Log("PlayerDead");
            _paused = true;
        }


        public void Unload()
        { 
        }
    }
}