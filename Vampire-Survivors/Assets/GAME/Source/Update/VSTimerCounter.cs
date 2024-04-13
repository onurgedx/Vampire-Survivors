using UnityEngine;
namespace VampireSurvivors.Update
{
    public class VSTimerCounter
    {
        private float _duration;
        private float _timeCounter;
        public VSTimerCounter(float a_duration)
        {
            _duration = a_duration;
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
