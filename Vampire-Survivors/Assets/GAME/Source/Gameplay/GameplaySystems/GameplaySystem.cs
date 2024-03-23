using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.AIControl;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.Systems.ChestSys;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Gameplay.Systems.HealSys;
using VampireSurvivors.Gameplay.Systems.LevelSys;
using VampireSurvivors.Gameplay.Systems.ManaSys;
using VampireSurvivors.Gameplay.Systems.PlayerControlSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems
{
    public class GameplaySystem : VSSystem
    {

        public SkillSystem SkillSystem { get; private set; }
        public CraftingSystem CraftingSystem{ get; private set; }
        public PlayerControlSystem PlayerControlSystem { get; private set; }
        public CollectionSystem CollectionSystem { get; private set; }
        public ManaSystem ManaSystem { get; private set; }
        public HealSystem HealSystem { get; private set; }
        public ChestSystem ChestSystem { get; private set; }
        public BattleSystem BattleSystem { get; private set; }
        public AIControlSystem AIControlSystem { get; private set; }        
        public LevelSystem LevelSystem { get; private set; }

        private Transform _chestParentTransform;

        public GameplaySystem()
        {
            Property<bool> canPlayerMove = new Property<bool>(true);

            PlayerControlSystem = new PlayerControlSystem(canPlayerMove);
            CraftingSystem = new CraftingSystem(PlayerControlSystem);
            //AIControlSystem = new AIControlSystem();
            SkillSystem = new SkillSystem();

            
            CollectionSystem = new CollectionSystem();
            ChestSystem = new ChestSystem(CollectionSystem, CraftingSystem.UnitCraftingSystem.PlayerTransform, 6, _chestParentTransform);
            ManaSystem = new ManaSystem(CollectionSystem);
            HealSystem = new HealSystem(CollectionSystem);
        }


        

        public override void Update()
        {
            base.Update();
            PlayerControlSystem.Update();
            ChestSystem.Update();
        }       

    }
}