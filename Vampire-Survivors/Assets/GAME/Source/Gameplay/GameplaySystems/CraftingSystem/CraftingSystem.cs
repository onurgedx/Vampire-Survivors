using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems
{
    public class CraftingSystem : VSSystem
    { 
        public UnitCraftingSystem UnitCraftingSystem { get; private set; }


        public CraftingSystem(PlayerControlSystem a_playeControlSystem, AIControlSystem a_aiControlSystem, DamageableRecorder a_damageableRecorder)
        {
            UnitCraftingSystem = new UnitCraftingSystem(a_playeControlSystem, a_aiControlSystem, a_damageableRecorder);
        }

        public override void Update()
        {
            base.Update();
            UnitCraftingSystem.Update();
        }
    }
}