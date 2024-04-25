
namespace VampireSurvivors
{
    /// <summary>
    /// Introduction for scenes
    /// </summary>
    public abstract class SceneEntry : VSBehavior
    {
        public abstract void Load();

        public abstract void Unload();
         
    }
}
