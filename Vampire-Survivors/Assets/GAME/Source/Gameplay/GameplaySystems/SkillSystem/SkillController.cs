using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillController<T> where T : Skill
    {
        private VSObjectPool<SkillBehaviour> _behaviorPool;

        public T Skill { get; protected set; }


        public SkillController(T a_skill)
        {
            Skill = a_skill;
        }


        public void Update()
        {
            if (Skill.TimeCounter >= Skill.Cooldown)
            {
                Skill.TimeCounter = 0;
                Process();
            }
        }

        protected virtual void Process()
        {
            if (_behaviorPool.TryRetrieve(out SkillBehaviour skillBehavior))
            {
                skillBehavior.Init(Skill);

            }

        }


        public virtual void LevelUp()
        {

        }



    }
}