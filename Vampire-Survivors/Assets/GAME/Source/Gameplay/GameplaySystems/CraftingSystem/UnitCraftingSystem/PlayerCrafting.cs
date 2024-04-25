using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Completables; 

namespace VampireSurvivors.Gameplay.Systems
{
    /// <summary>
    /// Crafts Player
    /// </summary>
    public class PlayerCrafting
    {

        private PlayerUnitFactory _factory= new PlayerUnitFactory( );
         

        public void CraftPlayer(PlayerControlSystem a_playerControlSystem,
                                PlayerHPFrame a_playerHPFrame,
                                IDamageablePlayerRecorder a_damageableRecorder, 
                                Transform a_poolTransform ,
                                Completable<PlayerUnit> a_completablePlayerUnit)
        {
            AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(  Keys.PlayerDefault );
            asyncOperationHandle.Completed += (asyncOperationHandle) =>
            {
                (PlayerUnit unit, UnitBehaviour playerUnitBehavior) = _factory.Create(a_playerControlSystem,
                                                                                      asyncOperationHandle.Result,
                                                                                      a_damageableRecorder,
                                                                                      a_playerHPFrame, 
                                                                                      a_poolTransform);
                a_completablePlayerUnit.Value = unit;
                a_completablePlayerUnit.Complete();
            };
        }
    }
}