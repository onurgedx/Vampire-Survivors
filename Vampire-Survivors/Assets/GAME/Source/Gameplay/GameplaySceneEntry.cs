using UnityEngine;
using VampireSurvivors.Gameplay.Systems;
using VampireSurvivors.Gameplay.Systems.LevelSys;

namespace VampireSurvivors.Gameplay
{
    public class GameplaySceneEntry : SceneEntry
    {
        public static readonly string GameplaySystemScene = "GameplaySystem";
        public GameplaySystem GameplaySystem { get; private set; }
        [SerializeField] private LevelDatas _levelData;


        public override void Load()
        {
            GameplaySystem = new GameplaySystem(_levelData);
        }

        private void Update()
        {
            GameplaySystem?.Update();   
        }

        public override void Show()
        {
            throw new System.NotImplementedException();
        }

        public override void Hide()
        {
            throw new System.NotImplementedException();
        }
    }
}