
using UnityEngine;
namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamageablePlayerRecorder
    {
        public void RecordPlayer(GameObject a_playerGameobject, IDamageable a_damageablePlayer);
    }
}
