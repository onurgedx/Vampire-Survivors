using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems
{

    public abstract class AbstractCollectableSpawnSystem :VSSystem
    {
        protected Spawner _spawner;

        protected AbstractCollectableSpawnSystem(CollectableRecorder a_collectableRecorder, Spawner a_spawner)
        {
            _spawner = a_spawner;
        }
    }
    
}
