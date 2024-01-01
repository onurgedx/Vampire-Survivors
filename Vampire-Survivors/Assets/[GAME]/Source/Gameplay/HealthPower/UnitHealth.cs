using System;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Units
{
    public class UnitHealth
    {
        private static int c_defaultMaxUnitHealth = 100;

        public Action Changed ;

        public Action Dead;

        public IProperty<int> CurrentHealth => _currentHealth;
        private Property<int> _currentHealth;

        public IProperty<int> MaxHealth => _maxHealth;
        private Property<int> _maxHealth;
        

        public UnitHealth()
        {
            _maxHealth = new Property<int>(c_defaultMaxUnitHealth);
            _currentHealth = new Property<int>(_maxHealth.Value);
        }


        public void UpdateCurrentHealth(int a_add2CurrentHealth)
        {
            int health = Math.Clamp(_currentHealth.Value + a_add2CurrentHealth, 0, _maxHealth.Value);
            _currentHealth.SetValue(health);
            Changed?.Invoke();
            if (health == 0)
            {
                Dead?.Invoke();
            }
        }

        public void UpdateMaxHealth(int a_add2MaxHealth)
        {
            int maxHealth = Math.Max( _maxHealth.Value + a_add2MaxHealth,1);
            _maxHealth.SetValue(maxHealth);
            _currentHealth.SetValue(Math.Min(_currentHealth.Value, maxHealth));
            Changed?.Invoke();


        }

    }
}