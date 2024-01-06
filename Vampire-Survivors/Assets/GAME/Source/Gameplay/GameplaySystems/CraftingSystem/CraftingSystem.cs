using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems
{
    public class CraftingSystem : VSSystem
    { 
        public UnitCraftingSystem UnitCraftingSystem { get; private set; }


        public CraftingSystem(PlayerControlSystem a_playeControlSystem)
        { 
            UnitCraftingSystem = new UnitCraftingSystem( a_playeControlSystem);
        }
    }
}