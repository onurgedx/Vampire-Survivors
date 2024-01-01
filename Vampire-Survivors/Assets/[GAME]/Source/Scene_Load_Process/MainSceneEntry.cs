
using UnityEngine.SceneManagement;
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
        

        private void Start()
        {
            LoadMenuUI();
        }


        private void LoadMenuUI()
        {
            // Use it for After Scene be Loaded
            //SceneManager.LoadSceneAsync( Scene_MenuUI , LoadSceneMode.Additive).completed;
        }


    }
}