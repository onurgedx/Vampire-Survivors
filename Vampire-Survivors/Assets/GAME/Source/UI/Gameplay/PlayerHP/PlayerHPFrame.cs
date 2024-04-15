using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.UI.PlayerHP
{
    public class PlayerHPFrame: IPlayerHPFrame
    {
        public IActionProperty<int> CurrentHP=> _currentHP;
        private ActionProperty<int> _currentHP;

        public IActionProperty<int> MaxHP => _maxHP;
        private ActionProperty<int> _maxHP;

        public PlayerHPFrame()
        {
            _maxHP = new ActionProperty<int>(100);
            _currentHP = new ActionProperty<int>(100);
        }


        public void UpdateHP(int a_hp)
        {
            _currentHP.SetValue(a_hp);
        }


        public void UpdateMaxHP(int a_maxHP)
        {
            _maxHP.SetValue(a_maxHP);
        }
    }
}