using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectableRecorder : Recorder<Collider, ICollectable>
    {
        public CollectableRecorder(Dictionary<Collider, ICollectable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}