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
         
        private EnemyUnitFactory _unitFactory;
        private List<string> _unitNames= new List<string>();

        public EnemyUnitCrafting(EnemyUnitFactory a_enemyUnitFactory)
        {
            _unitFactory = a_enemyUnitFactory; 
        }


        public void CreateEnemy(WaveData a_waveData)
        {
            foreach (EnemyData data in a_waveData.EnemyDatas)
            {                 
                    for (int i = 0; i < data.Count; i++)
                    {
                        _unitFactory.CreateEnemyUnit(data.Data);
                    }
                }
            }
        


        public void LoadEnemyUnitsPrefabs(EnemyWaveDatas a_waveDatas)
        {
            foreach (WaveData waveData in a_waveDatas.WaveDatas)
            {
                foreach (EnemyData enamyData in waveData.EnemyDatas)
                {
                    if (!_unitNames.Contains(enamyData.Data.UnitName))
                    {
                        _unitNames.Add(enamyData.Data.UnitName);
                        AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(enamyData.Data.UnitName);
                        asyncOperationHandle.Completed += (asyncOperationHandle) =>
                        {
                            _unitFactory.AddEnemyPrefab(enamyData.Data.UnitName, asyncOperationHandle.Result);
                        };
                    }
                }


            }
        }
    }
}