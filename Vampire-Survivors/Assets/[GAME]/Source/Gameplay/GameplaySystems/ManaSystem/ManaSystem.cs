using System.Collections.Generic;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSystem :VSSystem
    {
        private ManaSpawner _manaSpawner;

        public ManaSystem(CollectableRecorder a_collectableRecorder, Dictionary<System.Type, ManaFactory> a_manaFactories)
        {
            _manaSpawner = new ManaSpawner( a_collectableRecorder, a_manaFactories);
        }

    }
}