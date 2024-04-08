
using UnityEngine; 

namespace VampireSurvivors.Gameplay.UI
{
    public class GameplayUISceneEntry : SceneEntry
    {


        public static readonly string GameplayUIScene = "UI.Gameplay";
         

        public GameplayUI GameplayUI { get; private set; }

        

        public override void Load()
        {
            GameplayUI = new GameplayUI(); 

        }

        
    }   
}