using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.CraftingSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems
{
    public class CraftingSystem : VSSystem
    {
        private EnemyUnitCrafting _enemyUnitCraftingSystem { get; set; }

        private PlayerCrafting _playerCraftig = new PlayerCrafting();

        private VSTimerCounter _enemyCreateTimer;
        public IProperty<IUnitHealth> PlayerUnitHealth => _playerUnitHealth;
        private Property<IUnitHealth> _playerUnitHealth;
        private List<WaveData> _enemyWaveDatas;
        private int _currentWave = 0;
        public Action NoRemainsEnemyWave;


        public CraftingSystem(PlayerControlSystem a_playeControlSystem,
                              EnemyMovementControl a_enemyMovementControl,
                              DamageableRecorder a_damageableRecorder,
                              PlayerHPFrame a_playerHPFrame,
                              DamageSourceTypeRecorder a_damageSourceTypeRecorder,
                              EnemyWaveDatas a_enemyWaveData,
                              float a_waveDuration,
                              Transform a_poolTransform)
        {
            _enemyCreateTimer = new VSTimerCounter(a_waveDuration, a_waveDuration - 2);
               _enemyWaveDatas = a_enemyWaveData.WaveDatas;
            _playerUnitHealth = new Property<IUnitHealth>(null);
            _playerCraftig.CraftPlayer(a_playeControlSystem, a_playerHPFrame, a_damageableRecorder, _playerUnitHealth, a_poolTransform);

            EnemyUnitFactory enemyFactory = new EnemyUnitFactory(a_playeControlSystem.Position, a_enemyMovementControl, a_damageableRecorder, a_damageSourceTypeRecorder, a_poolTransform);
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