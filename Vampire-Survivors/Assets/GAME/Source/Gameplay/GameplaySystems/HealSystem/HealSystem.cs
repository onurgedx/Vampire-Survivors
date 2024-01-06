using VampireSurvivors.Gameplay.Systems.CollectionSys;
namespace VampireSurvivors.Gameplay.Systems.HealSys
{
    public class HealSystem : AbstractCollectableSpawnSystem
    {
        public HealSystem(CollectableRecorder a_collectableRecorder, Spawner a_spawner) : base(a_collectableRecorder, a_spawner)
        {
        }
    }
}
