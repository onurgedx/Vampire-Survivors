using System;

namespace VampireSurvivors.Lib.Basic.Properties
{
    /// <summary>
    /// Property contains Action intending to notify value is changed
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ActionProperty<T> : Property<T> , IActionProperty<T>
    {
        private Action _changed;
        public ActionProperty(T a_value) : base(a_value)
        {
        }

        public override void SetValue(T a_value)
        {
            base.SetValue(a_value);
            _changed?.Invoke();
        }

        public void RunOnChange(Action a_action)
        {
            _changed +=a_action;
        }
    }
}