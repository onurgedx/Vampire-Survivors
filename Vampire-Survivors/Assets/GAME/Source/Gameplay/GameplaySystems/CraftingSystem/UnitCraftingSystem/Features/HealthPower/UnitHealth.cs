using System;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Units
{
    /// <summary>
    /// Responsible for a unit's Health parameters
    /// </summary>
    public class UnitHealth
    {
        public Action Changed ;
        public Action Dead;

        public IProperty<int> CurrentHealth => _currentHealth;
        private Property<int> _currentHealth;

        public IProperty<int> MaxHealth => _maxHealth;
        private Property<int> _maxHealth;
        

        public UnitHealth(int a_maxHealth)
        {
            _maxHealth = new Property<int>(a_maxHealth);
            _currentHealth = new Property<int>(a_maxHealth);
        }


        /// <summary>
        /// Updates unit's current health by adding given parameter
        /// </summary>
        /// <param name="a_add2CurrentHealth">Additional Health Amount</param>
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


        /// <summary>
        /// Updates unit's max health by adding given parameter
        /// </summary>
        /// <param name="a_add2MaxHealth">Additional Max Health Amount</param>
        public void UpdateMaxHealth(int a_add2MaxHealth)
        {
            int maxHealth = Math.Max( _maxHealth.Value + a_add2MaxHealth,1);
            _maxHealth.SetValue(maxHealth);
            _currentHealth.SetValue(Math.Min(_currentHealth.Value, maxHealth));
            Changed?.Invoke();
        }
    }
}