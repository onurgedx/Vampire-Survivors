 
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamageableRecorder
    {
        public void Record(int a_gameobject,IDamageable a_damageable);
    }
}