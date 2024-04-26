
using System;
using System.Collections.Generic; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    /// <summary>
    /// Records Damagables by HashCode
    /// </summary>
    public class DamageableRecorder : Recorder<int, IDamageable> ,  IDamageableRecorder
    { 
        public DamageableRecorder(Dictionary<int, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }         

    }
}