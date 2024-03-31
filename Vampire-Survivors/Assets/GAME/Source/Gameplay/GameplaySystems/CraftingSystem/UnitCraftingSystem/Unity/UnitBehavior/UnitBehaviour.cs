
namespace VampireSurvivors.Gameplay.Units
{
    public class UnitBehaviour : VSBehavior
    {
        public void Init(Unit a_unit)
        {            
            a_unit.OnDead += Dead;
        }

        private void Dead()
        {
            gameObject.SetActive(false);
        }
    }
}