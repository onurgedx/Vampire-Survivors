
using System;
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Lib.Record;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public class DamageableRecorder : Recorder<GameObject, IDamageable> , IDamageablePlayerRecorder , IDamagableRecorder
    {
        public Action<GameObject> DamageablePlayerRecoreded;
        public DamageableRecorder(Dictionary<GameObject, IDamageable> a_recordeds) : base(a_recordeds)
        {
        }        


        public void RecordPlayer(GameObject a_playerGameobject,IDamageable a_damageablePlayer)
        {
            Record(a_playerGameobject, a_damageablePlayer);
            DamageablePlayerRecoreded.Invoke(a_playerGameobject);
        }

    }
}