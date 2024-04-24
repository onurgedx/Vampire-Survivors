
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Units
{
    public interface IUnitHealth
    {
        public IProperty<int> CurrentHealth { get; }
        public IProperty<int> MaxHealth { get; }
        public void UpdateCurrentHealth(int a_add2CurrentHealth);
        public void UpdateMaxHealth(int a_add2MaxHealth);
    }
}