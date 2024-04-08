
namespace VampireSurvivors
{
    public abstract class SceneEntry : VSBehavior
    {
        public abstract void Load();

        public virtual void Unload()
        {

        }
         
    }
}
