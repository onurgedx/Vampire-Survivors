using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems
{
    public class UnitCraftingSystem : VSSystem
    {

        private Dictionary<string, GameObject> _unitPrefabs = new Dictionary<string, GameObject>();
        private UnitFactory _unitFactory;
                 
        public IProperty<Transform> PlayerTransform => _playerTransform;
        private Property<Transform> _playerTransform { get;   set; }
        
        public Action _playerLoad;


        public UnitCraftingSystem(PlayerControlSystem a_playerControlSystem)
        {
            _unitFactory = new UnitFactory();
            _playerTransform = new Property<Transform>(null);
            _playerLoad = () => CraftPlayer(a_playerControlSystem);
            LoadUnitsPrefabs();
        }


        public void CraftPlayer(PlayerControlSystem a_playerControlSystem)
        {
            if (_unitPrefabs.TryGetValue(Keys.PlayerDefault, out GameObject playerGameobject))
            {
                _playerTransform.SetValue ( playerGameobject.transform);
                PlayerUnit unit = _unitFactory.CreatePlayerUnit(a_playerControlSystem, playerGameobject);
            }
        }


        private void LoadUnitsPrefabs()
        {
            foreach (string unitKey in Keys.Units)
            {
                AsyncOperationHandle<GameObject> asyncOperationHandle = Addressables.LoadAssetAsync<GameObject>(unitKey);
                asyncOperationHandle.Completed += (asyncOperationHandle) =>
                {
                    _unitPrefabs.Add(unitKey, asyncOperationHandle.Result);
                    if (unitKey == Keys.PlayerDefault)
                    {
                        _playerLoad?.Invoke();
                    }
                };
            }
        }

    }
}