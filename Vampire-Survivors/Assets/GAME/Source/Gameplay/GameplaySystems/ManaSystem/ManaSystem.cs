using VampireSurvivors.Gameplay.Systems.CollectionSys;

namespace VampireSurvivors.Gameplay.Systems.ManaSys
{
    public class ManaSystem : AbstractCollectableSpawnSystem
    {
        public ManaSystem(CollectableRecorder a_collectableRecorder, Spawner a_spawner) : base(a_collectableRecorder,a_spawner)
        {
        }
         
    }
}