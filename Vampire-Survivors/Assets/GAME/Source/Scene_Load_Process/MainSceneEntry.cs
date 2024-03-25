
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.Systems.LevelSys;

namespace VampireSurvivors.SceneProcess
{   
    /// <summary>
    /// 
    /// </summary>
    public class MainSceneEntry : VSBehavior
    {
        public static readonly string Scene_GameplayUI = "UI.Gameplay";
        public static readonly string Scene_MenuUI = "UI.Menu";
        public static readonly string Scene_Camera = "Camera";
        private GameplaySystem _gameplaySystem;
        [SerializeField] private LevelDatas _levelData;

        public void Start()
        {
            LoadMenuUI();
            _gameplaySystem= new GameplaySystem(_levelData);
        }


        private void Update()
        {
            _gameplaySystem.Update();
        }


        private void LoadMenuUI()
        {
            // Use it for After Scene be Loaded
            //SceneManager.LoadSceneAsync( Scene_MenuUI , LoadSceneMode.Additive).completed;
        }
    }
}