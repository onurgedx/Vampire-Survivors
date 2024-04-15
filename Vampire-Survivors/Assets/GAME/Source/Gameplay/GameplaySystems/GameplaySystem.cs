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
using VampireSurvivors.Lib.Basic.Properties;

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

        private Transform _chestParentTransform;
        private Transform _manaParentTransform;
        private LevelDatas _levelData;

        private bool _paused = false;


        public GameplaySystem(LevelDatas a_levelDatas ,GameplayUI a_gameplayUI  )
        {
            _levelData = a_levelDatas;
            Property<bool> canPlayerMove = new Property<bool>(true);
            PlayerControlSystem = new PlayerControlSystem(canPlayerMove);

            BattleSystem = new BattleSystem(PlayerControlSystem.Position);
            BattleSystem.PlayerDead += LoseGame;

            AIControlSystem = new AIControlSystem(PlayerControlSystem.Position); 

            CraftingSystem = new CraftingSystem(PlayerControlSystem,
                                                AIControlSystem.EnemyMovementControl,
                                                BattleSystem.DamageRecorder,
                                                a_gameplayUI.PlayerHPFrame,
                                                BattleSystem.GameObjectDamageSourceTypeRecorder);  
            
            SkillSystem = new SkillSystem( PlayerControlSystem.Position, PlayerControlSystem.Direction, a_gameplayUI.SkillChooseFrame);
            SkillSystem.DamageRequest += BattleSystem.Damage;
            SkillSystem.SkillRequested += PauseGame;
            SkillSystem.SkillChoosed += ContinueGame;


            LevelSystem = new LevelSystem(_levelData,SkillSystem, a_gameplayUI.GameplayUILevel);
                        
            CollectionSystem = new CollectionSystem(); 
            ChestSystem = new ChestSystem(CollectionSystem, PlayerControlSystem.Position, (int)Mathf.Pow(2,6) , _chestParentTransform, SkillSystem);
            ManaSystem = new ManaSystem(CollectionSystem, PlayerControlSystem.Position, (int)Mathf.Pow(2, 8), _manaParentTransform, LevelSystem);
            HealSystem = new HealSystem(CollectionSystem, PlayerControlSystem.Position, (int)Mathf.Pow(2, 7), _manaParentTransform, CraftingSystem.PlayerUnitHealth);
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