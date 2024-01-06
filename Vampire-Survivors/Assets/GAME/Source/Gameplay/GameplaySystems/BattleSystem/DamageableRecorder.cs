 
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageableRecorder : Recorder<Collider, IDamageable>
    {
        public DamageableRecorder(Dictionary<Collider, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }
    }
}