using VampireSurvivors.CameraSystems;
using VampireSurvivors.Gameplay;
using VampireSurvivors.Gameplay.Systems; 
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.UI.Menu;

namespace VampireSurvivors.SceneProcess
{
    /// <summary>
    /// 
    /// </summary>
    public class MainSceneEntry : SceneEntry
    {
        public static readonly string SceneName = "MAIN";
        private VSSceneManager _vsSceneManager;

        public override void Load()
        { 
        }

        public void Start()
        {
            _vsSceneManager = new VSSceneManager( );
            LoadMenuUI();
        }

        public override void Unload()
        { 
        }

        private void LoadMenuUI()
        {
            Completable<UIMenuSceneEntry> uiMenuCompletable = _vsSceneManager.LoadAdditive<UIMenuSceneEntry>(UIMenuSceneEntry.Scene_MenuUI);
            uiMenuCompletable.RunOnCompleted(UnloadScene);
        }

        private void UnloadScene()
        {
            _vsSceneManager.Unload<MainSceneEntry>(MainSceneEntry.SceneName);
        }


         
    }
}
