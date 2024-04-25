
using System;
using System.Collections.Generic; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    /// <summary>
    /// Records Damagables by HashCode
    /// </summary>
    public class DamageableRecorder : Recorder<int, IDamageable> , IDamageablePlayerRecorder , IDamagableRecorder
    {
        public Action<int> DamageablePlayerRecoreded;
        public DamageableRecorder(Dictionary<int, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }        

        /// <summary>
        /// Records player as damagable and Notify Especially
        /// </summary>
        /// <param name="a_playerGameobject"></param>
        /// <param name="a_damageablePlayer"></param>
        public void RecordPlayer(int a_playerGameobject,IDamageable a_damageablePlayer)
        {
            Record(a_playerGameobject.GetHashCode(), a_damageablePlayer);
            DamageablePlayerRecoreded.Invoke(a_playerGameobject);
        }

    }
}