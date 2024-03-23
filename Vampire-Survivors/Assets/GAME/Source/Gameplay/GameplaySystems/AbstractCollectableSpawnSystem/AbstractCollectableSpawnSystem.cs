using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems
{

    public abstract class AbstractCollectableSpawnSystem :VSSystem
    {
        protected CollectableSpawner _spawner;
        protected CollectableRecorder _collectableRecorder;

        protected AbstractCollectableSpawnSystem(CollectableRecorder a_collectableRecorder, CollectableSpawner a_spawner)
        {
            _spawner = a_spawner;
            _collectableRecorder = a_collectableRecorder;
        }
    }
    
}
