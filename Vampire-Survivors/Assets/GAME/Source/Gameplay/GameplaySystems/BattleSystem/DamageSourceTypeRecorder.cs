using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageSourceTypeRecorder : Recorder<GameObject, int>
    {
        public DamageSourceTypeRecorder(Dictionary<GameObject, int> a_recordeds) : base(a_recordeds)
        {
        }
    }
}