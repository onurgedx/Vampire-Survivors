
using TMPro;
using UnityEngine;

namespace VampireSurvivors.Gameplay.UI.GameTime
{

    public class TimeFrameBehavior : VSBehavior
    {

        [SerializeField] private TextMeshProUGUI _text;
        

        public void Init(TimeFrame a_timeFrame)
        {
            a_timeFrame.Time.RunOnChange(() => _text.text = a_timeFrame.Time.Value);
        }
    }
}