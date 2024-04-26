using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.CraftingSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.Lib.Record;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems
{

    /// <summary>
    /// Controls Creating Process of Player and Enemies
    /// </summary>
    public class CraftingSystem : VSSystem
    {
        public Action NoRemainsEnemyWave;
        public PlayerUnit PlayerUnit { get; private set; }
        private EnemyUnitCrafting _enemyUnitCraftingSystem { get; set; }
        private PlayerCrafting _playerCraftig = new PlayerCrafting();
        private VSTimerCounter _enemyCreateTimer;
        private List<WaveData> _enemyWaveDatas;
        private int _currentWave = 0;


        public CraftingSystem(PlayerControlSystem a_playeControlSystem,
                              EnemyMovementControl a_enemyMovementControl,
                              IDamageableRecorder a_damageableRecorder,
                              PlayerHPFrame a_playerHPFrame,
                              IRecorder<GameObject, int> a_enemyDamageRecorder,
                              EnemyWaveDatas a_enemyWaveData,
                              float a_waveDuration,
                              Transform a_poolTransform,
                              Completable<PlayerUnit> a_completablePlayerUnit)
        {
            _enemyCreateTimer = new VSTimerCounter(a_waveDuration, a_waveDuration - 2);
            _enemyWaveDatas = a_enemyWaveData.WaveDatas;

            _playerCraftig.CraftPlayer(a_playeControlSystem, a_playerHPFrame, a_damageableRecorder, a_poolTransform, a_completablePlayerUnit);
            a_completablePlayerUnit.RunOnCompleted(() => PlayerUnit = a_completablePlayerUnit.Value);

            EnemyUnitFactory enemyFactory = new EnemyUnitFactory(a_playeControlSystem.Position, a_enemyMovementControl, a_damageableRecorder, a_enemyDamageRecorder, a_poolTransform);
            _enemyUnitCraftingSystem = new EnemyUnitCrafting(enemyFactory);
            _enemyUnitCraftingSystem.LoadEnemyUnitsPrefabs(a_enemyWaveData);
        }


        public override void Update()
        {
            base.Update();
            if (_enemyWaveDatas.Count > _currentWave)
            {
                EnemyCreateProcess();
            }
            else
            {
                NoRemainsEnemyWave?.Invoke();
            }
        }


        private void EnemyCreateProcess()
        {
            if (_enemyCreateTimer.Process())
            {
                _enemyUnitCraftingSystem.CreateEnemy(_enemyWaveDatas[_currentWave]);
                _currentWave++;
            }
        }
    }
}