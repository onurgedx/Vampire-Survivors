using System;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltLevels 
    {
        public class MagicBoltLevel1 { }
        public class MagicBoltLevel2 { }
        public class MagicBoltLevel3 { }
        public class MagicBoltLevel4 { }
        public class MagicBoltLevel5 { }
        public class MagicBoltLevel6 { }
        public class MagicBoltLevel7 { }

        public static readonly Type[] Levels = new Type[] { typeof(MagicBoltLevel1), typeof(MagicBoltLevel2), typeof(MagicBoltLevel3), typeof(MagicBoltLevel4), typeof(MagicBoltLevel5), typeof(MagicBoltLevel6), typeof(MagicBoltLevel7) };

    }
}