using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.BattleSys
{
    public interface IDamagableRecorder
    {
        public void Record(GameObject a_gameobject,IDamageable a_damageable);
    }
}