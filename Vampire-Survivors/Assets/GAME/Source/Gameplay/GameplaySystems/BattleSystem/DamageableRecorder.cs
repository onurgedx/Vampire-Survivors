 
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageableRecorder : Recorder<GameObject, IDamageable>
    {
        public DamageableRecorder(Dictionary<GameObject, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}