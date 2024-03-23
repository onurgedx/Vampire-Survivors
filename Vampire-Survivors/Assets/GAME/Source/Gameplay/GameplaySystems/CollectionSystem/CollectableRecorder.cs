using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectableRecorder : Recorder<GameObject, ICollectable>
    {
        public CollectableRecorder(Dictionary<GameObject, ICollectable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}