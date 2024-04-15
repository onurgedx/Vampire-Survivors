using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations; 
using VampireSurvivors.Gameplay.Systems.CraftingSys; 
using VampireSurvivors.Gameplay.Units; 

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


        public void CreateEnemy(EnemyData[] a_enemies)
        {
            foreach (EnemyData data in a_enemies)
            {
                if (_unitPrefabs.TryGetValue(data.Name, out GameObject enemyGo))
                {
                    for (int i = 0; i < data.Count; i++)
                    {
                        _unitFactory.CreateEnemyUnit(enemyGo, null);
                    }
                } 
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