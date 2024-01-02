
using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSystem :VSSystem
    {
        private ManaSpawner _manaSpawner;

        public ManaSystem(CollectableRecorder a_collectableRecorder)
        {
            _manaSpawner = new ManaSpawner( a_collectableRecorder);
        }

    }
}