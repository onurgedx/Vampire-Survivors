 
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamagableRecorder
    {
        public void Record(int a_gameobject,IDamageable a_damageable);
    }
}