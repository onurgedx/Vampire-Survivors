using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.ChestSys;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Systems.CraftingSys;
using VampireSurvivors.Gameplay.Systems.HealSys;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Gameplay.Systems.ManaSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Systems.SkillSys;
using VampireSurvivors.Gameplay.Systems.TimeSys;
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Completables;

namespace VampireSurvivors.Gameplay.Systems
{
    public class GameplaySystem : VSSystem
    {

        public SkillSystem SkillSystem { get; private set; }
        public CraftingSystem CraftingSystem { get; private set; }
        public PlayerControlSystem PlayerControlSystem { get; private set; }
        public AIControlSystem AIControlSystem { get; private set; }
        public CollectionSystem CollectionSystem { get; private set; }
        public ManaSystem ManaSystem { get; private set; }
        public HealSystem HealSystem { get; private set; }
        public ChestSystem ChestSystem { get; private set; }
        public BattleSystem BattleSystem { get; private set; }
        public LevelSystem LevelSystem { get; private set; }
        public TimeSystem TimeSystem { get; private set; }



        private LevelDatas _levelData;

        private bool _paused = true;

        private GameplayUI _gameplayUI;

        private Transform _poolTransform; 


        public GameplaySystem(LevelDatas a_levelDatas, GameplayUI a_gameplayUI, Transform a_poolTransform)
        {
            _gameplayUI = a_gameplayUI;
            _levelData = a_levelDatas;
            _poolTransform = a_poolTransform;
            Setup();
        }

        private void Setup()
        {
            SetupPlayerControlSystem();
            SetupBattleSystem();
            SetupAIControlSystem();
            Completable<PlayerUnit> completablePlayerUnit = new Completable<PlayerUnit>();
            SetupCraftingSystem(completablePlayerUnit);
            completablePlayerUnit.RunOnCompleted(ContinueSetupAfterPlayerUnitCrafted);
        }

        private void ContinueSetupAfterPlayerUnitCrafted()
        {
            SetupSkillSystem();
            SetupLevelSystem();
            SetupCollectionSystems();
            SetupTimeSystem();
            ContinueGame();
        }

        private void SetupPlayerControlSystem()
        {
            PlayerControlSystem = new PlayerControlSystem();
        }


        private void SetupAIControlSystem()
        {
            AIControlSystem = new AIControlSystem(PlayerControlSystem.Position);
        }


        private void SetupLevelSystem()
        {
            LevelSystem = new LevelSystem(_levelData.RequiredExperiences, SkillSystem, _gameplayUI.GameplayUILevel);
        }


        private void SetupCraftingSystem(Completable<PlayerUnit> a_completablePlayerUnit)
        {
            CraftingSystem = new CraftingSystem(PlayerControlSystem,
                                                AIControlSystem.EnemyMovementControl,
                                                BattleSystem.DamageableRecorder,
                                                _gameplayUI.PlayerHPFrame,
                                                BattleSystem.GameObjectDamageSourceTypeRecorder,
                                                _levelData.EnemyWaveDatas,
                                                _levelData.WaveDuration,
                                                _poolTransform,
                                                a_completablePlayerUnit);
            CraftingSystem.NoRemainsEnemyWave += WinGame;
        }


        private void SetupCollectionSystems()
        {
            CollectionSystem = new CollectionSystem();
            ChestSystem = new ChestSystem(CollectionSystem.CollectableRecorder,
                                          CollectionSystem.CollectorAdder,
                                          PlayerControlSystem.Position,
                                          _poolTransform,
                                          SkillSystem);
            ManaSystem = new ManaSystem(CollectionSystem.CollectableRecorder,
                                        CollectionSystem.CollectorAdder,
                                        PlayerControlSystem.Position,
                                        _poolTransform,
                                        LevelSystem); 
            HealSystem = new HealSystem(CollectionSystem.CollectableRecorder,
                                        CollectionSystem.CollectorAdder,
                                        PlayerControlSystem.Position,
                                        _poolTransform,
                                        CraftingSystem.PlayerUnit.Health);

        }


        private void SetupBattleSystem()
        {
            List<IAttackData> attackDatas = new List<IAttackData>();
            foreach (WaveData waveData in _levelData.EnemyWaveDatas.WaveDatas)
            {
                foreach (EnemyData enemyData in waveData.EnemyDatas)
                {
                    if (!attackDatas.Contains(enemyData.Data))
                    {
                        attackDatas.Add(enemyData.Data);
                    }
                }
            }
            BattleSystem = new BattleSystem(PlayerControlSystem.Position, attackDatas);
            BattleSystem.PlayerDead += LoseGame;

        }


        private void SetupSkillSystem()
        {
            SkillSystem = new SkillSystem(PlayerControlSystem.Position, PlayerControlSystem.Direction, _gameplayUI.SkillChooseFrame, _levelData.SkillDatas, CraftingSystem.PlayerUnit);
            SkillSystem.DamageRequest += BattleSystem.Damage;
            SkillSystem.DamageUpdated += BattleSystem.UpdateDamage;
            SkillSystem.SkillRequested += PauseGame;
            SkillSystem.SkillChoosed += ContinueGame;
        }

        
        private void SetupTimeSystem()
        {
            TimeSystem = new TimeSystem(_gameplayUI.TimeFrame);
        }


        public override void Update()
        {
            if (_paused  ) { return; }
            base.Update();
            PlayerControlSystem.Update();
            AIControlSystem.Update();
            ChestSystem?.Update();
            ManaSystem.Update();
            HealSystem.Update();
            CollectionSystem.Update();
            CraftingSystem.Update();
            SkillSystem.Update();
            BattleSystem.Update();
            TimeSystem.Update();
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
            PauseGame();
            _gameplayUI.GameplayFinishFrame.Win();
        }


        public void LoseGame()
        {
            PauseGame();
            _gameplayUI.GameplayFinishFrame.Lose();
        }
    }
}