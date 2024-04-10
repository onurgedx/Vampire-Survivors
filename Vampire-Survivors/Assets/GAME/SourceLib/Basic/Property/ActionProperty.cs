using System;

namespace VampireSurvivors.Lib.Basic.Properties
{
    public class ActionProperty<T> : Property<T> , IActionProperty<T>
    {
        private Action Changed;
        public ActionProperty(T a_value) : base(a_value)
        {
        }

        public override void SetValue(T a_value)
        {
            base.SetValue(a_value);
            Changed?.Invoke();
        }

        public void RunOnChange(Action a_action)
        {
            Changed +=a_action;
        }
    }
}