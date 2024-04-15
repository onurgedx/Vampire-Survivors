using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems
{
    public class PlayerCrafting
    {

        private PlayerUnitFactory _factory= new PlayerUnitFactory();
        public PlayerCrafting( )
        {
        }


        public void CraftPlayer(PlayerControlSystem a_playerControlSystem, PlayerHPFrame a_playerHPFrame,IDamageablePlayerRecorder a_damageableRecorder, Property<IUnitHealth> a_unitHealth)
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(  Keys.PlayerDefault );
            asyncOperationHandle.Completed += (asyncOperationHandle) =>
            {
                (PlayerUnit unit, UnitBehaviour playerUnitBehavior) = _factory.Create(a_playerControlSystem,
                                                                                      asyncOperationHandle.Result,
                                                                                      a_damageableRecorder,
                                                                                      a_playerHPFrame,
                                                                                      a_unitHealth);                
            };
        }
    }
}