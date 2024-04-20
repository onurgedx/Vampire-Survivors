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

        private bool _paused = false;

        private GameplayUI _gameplayUI;



        public GameplaySystem(LevelDatas a_levelDatas, GameplayUI a_gameplayUI, Transform a_poolTransform)
        {
            _gameplayUI = a_gameplayUI;
              _levelData = a_levelDatas;

            PlayerControlSystem = new PlayerControlSystem();

            SetupBattleSystem();

            AIControlSystem = new AIControlSystem(PlayerControlSystem.Position);
            SetupCraftingSystem(a_gameplayUI, a_poolTransform);
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
            TimeSystem = new TimeSystem(a_gameplayUI.TimeFrame);
        }


        private void SetupBattleSystem()
        {
            List<IAttackData> attackDatas = new List<IAttackData>();
            foreach (SkillData skillData in _levelData.SkillDatas)
            {
                attackDatas.AddRange(skillData.Levels);
            }
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


        private void SetupSkillSystem(GameplayUI a_gameplayUI)
        {
            SkillSystem = new SkillSystem(PlayerControlSystem.Position, PlayerControlSystem.Direction, a_gameplayUI.SkillChooseFrame, _levelData.SkillDatas);
            SkillSystem.DamageRequest += BattleSystem.Damage;
            SkillSystem.SkillRequested += PauseGame;
            SkillSystem.SkillChoosed += ContinueGame;
        }


        private void SetupCraftingSystem(GameplayUI a_gameplayUI, Transform a_poolTransform)
        {
            CraftingSystem = new CraftingSystem(PlayerControlSystem,
                                                AIControlSystem.EnemyMovementControl,
                                                BattleSystem.DamageRecorder,
                                                a_gameplayUI.PlayerHPFrame,
                                                BattleSystem.GameObjectDamageSourceTypeRecorder,
                                                _levelData.EnemyWaveDatas,
                                                _levelData.WaveDuration,
                                                a_poolTransform);
            CraftingSystem.NoRemainsEnemyWave += WinGame;
        }


        public override void Update()
        {
            if (_paused) { return; }
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