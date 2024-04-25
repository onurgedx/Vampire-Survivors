using System;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    /// <summary>
    /// Base Collectable
    /// </summary>
    public abstract class Collectable
    {
        public Action Collected;

        public virtual void Collect()
        {
            Collected?.Invoke();
            Collected = null;
        }
    }
}