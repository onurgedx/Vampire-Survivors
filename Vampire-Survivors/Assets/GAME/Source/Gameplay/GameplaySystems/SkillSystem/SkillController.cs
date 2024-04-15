using System; 
using UnityEngine;
using VampireSurvivors.Lib.Pooling;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillController
    {
        protected VSObjectPool<SkillBehaviour> _behaviorPool = new VSObjectPool<SkillBehaviour>();

        protected SkillBehaviorFactory _skillFactory;
        protected Skill _skill;
        private Action<Type,GameObject > SkillImpact;
        protected Type[] LevelTypes;
        public int Level => _level;
        protected int _level = 0;

        public SkillController()
        {
        }


        public void Update()
        {
            _skill.TimeCounter += Time.deltaTime;

            if (_skill.TimeCounter > _skill.Cooldown)
            {
                if (!_behaviorPool.TryRetrieve(out SkillBehaviour skillBehavior))
                {
                    skillBehavior = _skillFactory.Create();
                    skillBehavior.Impact += Impact;
                    _behaviorPool.Add(skillBehavior);
                }
                Play(skillBehavior);

                _skill.TimeCounter = 0;
            }
        }


        public abstract void Play(SkillBehaviour a_skillBehavior);


        protected void Impact(GameObject a_gameobject)
        {            
            SkillImpact?.Invoke(LevelTypes[_level], a_gameobject);
        }


        public void RunOnSkillImpact(Action<Type,GameObject > a_skillImpactAction)
        {
            SkillImpact += a_skillImpactAction;
        }

        public abstract void LevelUp();
    }
}