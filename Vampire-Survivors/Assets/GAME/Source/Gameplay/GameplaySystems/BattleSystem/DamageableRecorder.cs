
using System;
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageableRecorder : Recorder<int, IDamageable> , IDamageablePlayerRecorder , IDamagableRecorder
    {
        public Action<int> DamageablePlayerRecoreded;
        public DamageableRecorder(Dictionary<int, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }        


        public void RecordPlayer(int a_playerGameobject,IDamageable a_damageablePlayer)
        {
            Record(a_playerGameobject.GetHashCode(), a_damageablePlayer);
            DamageablePlayerRecoreded.Invoke(a_playerGameobject);
        }

    }
}