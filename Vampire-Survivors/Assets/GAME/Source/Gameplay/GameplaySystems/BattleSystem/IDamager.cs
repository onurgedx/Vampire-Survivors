 
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamager
    {
        /// <summary>
        /// Damages <paramref name="a_damageableGameObjectHashCode"/>  <paramref name="a_damage"/> amount damage
        /// </summary>
        /// <param name="a_damageableGameObjectHashCode">Target's Hash Code</param>
        /// <param name="a_damage">Amount of damage</param>
        public void Damage(int a_damageableGameObjectHashCode, int a_damage);
    }
}