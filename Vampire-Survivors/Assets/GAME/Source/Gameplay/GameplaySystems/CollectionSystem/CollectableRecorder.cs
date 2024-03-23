using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class CollectableRecorder : Recorder<GameObject, Collectable>
    {
        public CollectableRecorder(Dictionary<GameObject, Collectable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}