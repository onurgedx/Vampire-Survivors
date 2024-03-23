using System;

namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
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