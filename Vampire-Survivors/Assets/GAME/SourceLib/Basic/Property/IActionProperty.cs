using System; 
namespace VampireSurvivors.Lib.Basic.Properties
{
    public interface IActionProperty<T> :IProperty<T>
    {
        public void RunOnChange(Action a_action);
    }
}