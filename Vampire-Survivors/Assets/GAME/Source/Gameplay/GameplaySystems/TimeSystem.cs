using UnityEngine;
using VampireSurvivors.Gameplay.UI.GameTime;

namespace VampireSurvivors.Gameplay.Systems.TimeSys
{
    /// <summary>
    /// Calculates time
    /// </summary>
    public class TimeSystem : VSSystem
    {
        public float TimeCounter => _timeCounter;
        private float _timeCounter = 0;
        private TimeFrame _timeFrame;
        

        public TimeSystem(TimeFrame a_timeFrame)
        {
            _timeFrame = a_timeFrame;
        }

        public override void Update()
        {
            base.Update();

            float time = _timeCounter + Time.deltaTime;
            if ((int)time != (int)_timeCounter)
            {
                _timeFrame.UpdateTime((int)(time / 60), (int)(time % 60));
            }

            _timeCounter = time;

        }
    }
}
