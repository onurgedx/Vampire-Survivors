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

        private VSTimerCounter _enemyCreateTimer = new VSTimerCounter(60);

        public IProperty<IUnitHealth> PlayerUnitHealth => _playerUnitHealth;
        private Property<IUnitHealth> _playerUnitHealth;
        private EnemyWaveDatas _enemyWaveData;
        private int _currentWave=0;


        public CraftingSystem(PlayerControlSystem a_playeControlSystem,
                              EnemyMovementControl a_enemyMovementControl,
                              DamageableRecorder a_damageableRecorder,
                              PlayerHPFrame a_playerHPFrame,
                              DamageSourceTypeRecorder a_damageSourceTypeRecorder,
                              EnemyWaveDatas a_enemyWaveData)
        {
            _enemyWaveData = a_enemyWaveData;
               _playerUnitHealth = new Property<IUnitHealth>(null);
            _playerCraftig.CraftPlayer(a_playeControlSystem, a_playerHPFrame, a_damageableRecorder, _playerUnitHealth);

            EnemyUnitFactory enemyFactory = new EnemyUnitFactory(a_playeControlSystem.Position, a_enemyMovementControl, a_damageableRecorder, a_damageSourceTypeRecorder);
            _enemyUnitCraftingSystem = new EnemyUnitCrafting(enemyFactory);
        }


        public override void Update()
        {
            base.Update();
            EnemyCreateProcess();
        }


        private void EnemyCreateProcess()
        {

            if (_enemyCreateTimer.Process())
            {
                _currentWave++;
                // _enemyUnitCraftingSystem.CreateEnemy();

            }

        }



    }
}