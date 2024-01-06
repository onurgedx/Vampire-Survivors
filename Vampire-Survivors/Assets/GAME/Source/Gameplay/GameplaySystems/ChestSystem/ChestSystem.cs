using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ChestSys
{
    public class ChestSystem : AbstractCollectableSpawnSystem
    {
        public ChestSystem(CollectableRecorder a_collectableRecorder, Spawner a_spawner) : base(a_collectableRecorder, a_spawner)
        {
        }
    }
}