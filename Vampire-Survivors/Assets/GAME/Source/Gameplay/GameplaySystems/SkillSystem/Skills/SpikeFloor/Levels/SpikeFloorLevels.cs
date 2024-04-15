using System;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorLevels
    {
        public class SpikeFloorLevel1 { }
        public class SpikeFloorLevel2 { }
        public class SpikeFloorLevel3 { }
        public class SpikeFloorLevel4 { }
        public class SpikeFloorLevel5 { }
        public class SpikeFloorLevel6 { }
        public class SpikeFloorLevel7 { }

        public static readonly Type[] Levels = new Type[] { typeof(SpikeFloorLevel1), typeof(SpikeFloorLevel2), typeof(SpikeFloorLevel3), typeof(SpikeFloorLevel4), typeof(SpikeFloorLevel5), typeof(SpikeFloorLevel6), typeof(SpikeFloorLevel7) };
    }
}