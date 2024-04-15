using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.UI.PlayerHP
{
    public interface IPlayerHPFrame
    {
        public IActionProperty<int> CurrentHP { get; }
        public IActionProperty<int> MaxHP { get; }
    }
}