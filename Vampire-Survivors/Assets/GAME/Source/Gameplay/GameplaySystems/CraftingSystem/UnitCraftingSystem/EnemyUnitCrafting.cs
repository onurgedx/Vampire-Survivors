using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.UI.PlayerHP;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Update;

namespace VampireSurvivors.Gameplay.Systems
{
    public class EnemyUnitCrafting : VSSystem
    {

        private Dictionary<string, GameObject> _unitPrefabs = new Dictionary<string, GameObject>();
        private EnemyUnitFactory _unitFactory;  

        public EnemyUnitCrafting(EnemyUnitFactory a_enemyUnitFactory)
        {           
            _unitFactory = a_enemyUnitFactory;
            LoadEnemyUnitsPrefabs();
        }
        

        public void CreateEnemy()
        {
            if (_unitPrefabs.TryGetValue(Keys.EnemyDefault, out GameObject enemyGo))
            {
                 _unitFactory.CreateEnemyUnit(  enemyGo, null);                                
            } 
        }


        private void LoadEnemyUnitsPrefabs()
        {
            foreach (string unitKey in Keys.Units)
            {
                if (unitKey == Keys.PlayerDefault)
                { continue; }
                AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(unitKey);
                asyncOperationHandle.Completed += (asyncOperationHandle) =>
                {
                    _unitPrefabs.Add(unitKey, asyncOperationHandle.Result);
                };
            }
        }
    }
}