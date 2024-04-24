using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Pooling;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class ActiveSkillController : SkillController
    {
        protected VSObjectPool<SkillBehaviour> _behaviorPool = new VSObjectPool<SkillBehaviour>();
        protected SkillBehaviorFactory _skillBehaviorFactory;

        public ISkill Skill => _skill;
        protected Skill _skill { get; set; }
        private Action<int, int> SkillImpact;
        protected int _skillHashCode;

        protected Dictionary<Type, SkillImproveHelper> _skillImprovers = new Dictionary<Type, SkillImproveHelper>()
        {
            {typeof(CooldownDecreaseFeature),new CooldownDecreaser() },
            {typeof(SizeIncreaseFeature),new SizeIncreaser() },
            {typeof(DamageIncreaseFeature),new DamageIncreaser() },
            {typeof(CountIncreaseFeature),new CountIncreaser() },
        };

        public ActiveSkillController(Skill a_skill, int a_skillHashCode)
        {
            _skill = a_skill;
            _skillHashCode = a_skillHashCode;
        }


        public void Update()
        {
            _skill.TimeCounter += Time.deltaTime;

            if (_skill.TimeCounter > _skill.Cooldown)
            {
                for (int i = 0; i < _skill.Count; i++)
                {
                    if (!_behaviorPool.TryRetrieve(out SkillBehaviour skillBehavior))
                    {
                        skillBehavior = _skillBehaviorFactory.Create();
                        skillBehavior.Impact += Impact;
                        _behaviorPool.Add(skillBehavior);
                    }
                    Play(skillBehavior);
                }
                _skill.TimeCounter = 0;
            }
        }


        public override void LevelUp(SkillImprovement[] a_skillImprovments)
        {
            foreach (SkillImprovement skillImprovement in a_skillImprovments)
            {
                if (_skillImprovers.TryGetValue(skillImprovement.GetType(), out SkillImproveHelper skillImproveHelper))
                {
                    skillImproveHelper.Improve(skillImprovement, _skill);
                }
            }
        }


        protected abstract void Play(SkillBehaviour a_skillBehavior);


        protected void Impact(GameObject a_gameobject)
        {
            SkillImpact?.Invoke(_skillHashCode, a_gameobject.GetHashCode());
        }


        public void RunOnSkillImpact(Action<int, int> a_skillImpactAction)
        {
            SkillImpact += a_skillImpactAction;
        }
    }
}