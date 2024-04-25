
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.UI.GameTime
{
    /// <summary>
    /// Updates Gameplay Time's View
    /// </summary>
    public class TimeFrame
    {
        public IActionProperty<string> Time => _time;

        private ActionProperty<string> _time;

        public TimeFrame()
        {
            _time = new ActionProperty<string>("00:00");
        }

        public void UpdateTime(int a_minute, int a_second)
        {             
            _time.SetValue(a_minute.ToString() + ":" + a_second.ToString());
        }
    }
}
