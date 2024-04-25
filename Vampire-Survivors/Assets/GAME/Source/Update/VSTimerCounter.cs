using UnityEngine;
namespace VampireSurvivors.Update
{
    /// <summary>
    /// Calculates and process time progress
    /// </summary>
    public class VSTimerCounter
    {
        private float _duration;
        private float _timeCounter;
        public VSTimerCounter(float a_duration, float a_startTime =0)
        {
            _duration = a_duration;
            _timeCounter = a_startTime;
        }

        public bool Process()
        {
            _timeCounter += Time.deltaTime;
            if (_timeCounter > _duration)
            {
                _timeCounter = 0;
                return true;
            }
            return false;
        }
    }
}
