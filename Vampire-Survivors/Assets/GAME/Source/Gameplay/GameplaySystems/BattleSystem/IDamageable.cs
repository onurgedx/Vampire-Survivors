namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamageable
    {
        public bool IsAlive { get; }
        public void Damage(int a_damage);

    }
}