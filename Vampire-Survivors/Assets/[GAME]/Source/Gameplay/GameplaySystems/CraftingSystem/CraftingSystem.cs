namespace VampireSurvivors.Gameplay.Systems
{
    public class CraftingSystem : VSSystem
    { 
        public UnitCraftingSystem UnitCraftingSystem { get; private set; }


        public CraftingSystem()
        {
            UnitCraftingSystem = new UnitCraftingSystem();
        }
    }
}