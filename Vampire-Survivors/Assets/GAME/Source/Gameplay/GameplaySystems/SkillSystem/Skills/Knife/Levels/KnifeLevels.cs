using System;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeLevels  
    {
        public class KnifeLevel1 { }
        public class KnifeLevel2 { }
        public class KnifeLevel3 { }
        public class KnifeLevel4 { }
        public class KnifeLevel5 { }
        public class KnifeLevel6 { }
        public class KnifeLevel7 { }

        public static readonly Type[] Levels = new Type[] { typeof(KnifeLevel1), typeof(KnifeLevel2), typeof(KnifeLevel3), typeof(KnifeLevel4), typeof(KnifeLevel5), typeof(KnifeLevel6), typeof(KnifeLevel7) };

    }
}