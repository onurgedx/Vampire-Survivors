using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageSourceTypeRecorder : Recorder<GameObject, Type>
    {
        public DamageSourceTypeRecorder(Dictionary<GameObject, Type> a_recordeds) : base(a_recordeds)
        {
        }
    }
}