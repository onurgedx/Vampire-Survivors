
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public interface ISkill
    {
        public  float  Cooldown { get;   }
        public  float  Duration { get;   }
        public  int     Damage { get;  } 
        public  float  Size { get; }
        public int Count { get;  }
    }
}