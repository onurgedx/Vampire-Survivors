using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Record;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    /// <summary>
    /// Records Collectables
    /// </summary>
    public class CollectableRecorder : Recorder<GameObject, Collectable>
    {
        public CollectableRecorder(Dictionary<GameObject, Collectable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}