
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class Skill
    {

        public float TimeCounter;
        public float Cooldown { get; set; }
        public float Damage { get; private set; }
        public int Level { get; private set; }

        public Skill(float a_cooldown, float a_damage)
        {
            Level = 0;
            Cooldown = a_cooldown;
            Damage = a_damage;
        }
    }
}