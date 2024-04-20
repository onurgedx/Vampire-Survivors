using System; 
using UnityEngine;
using VampireSurvivors.Lib.Pooling;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class SkillController
    {
        protected VSObjectPool<SkillBehaviour> _behaviorPool = new VSObjectPool<SkillBehaviour>();

        protected SkillBehaviorFactory _skillBehaviorFactory;
        protected Skill _skill;
        private Action<int,int > SkillImpact;        
        protected int _skillLevelHash;

        public SkillController(Skill a_skill,int a_skillLevelHash)
        {
            _skill = a_skill;
            _skillLevelHash = a_skillLevelHash;
        }


        public void Update()
        {
            _skill.TimeCounter += Time.deltaTime;

            if (_skill.TimeCounter > _skill.Cooldown)
            {
                if (!_behaviorPool.TryRetrieve(out SkillBehaviour skillBehavior))
                {
                    skillBehavior = _skillBehaviorFactory.Create();
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
            SkillImpact?.Invoke(_skillLevelHash, a_gameobject.GetHashCode());
        }


        public void RunOnSkillImpact(Action<int,int > a_skillImpactAction)
        {
            SkillImpact += a_skillImpactAction;
        }

        public virtual void LevelUp(int a_skillLevelHash, float a_cooldown, float a_duration)
        {
            _skillLevelHash = a_skillLevelHash;
            _skill.Cooldown = a_cooldown;
            _skill.Duration = a_duration;
        }
    }
}