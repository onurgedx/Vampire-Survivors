using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Pooling;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public abstract class ActiveSkillController : SkillController 
    {
        protected VSObjectPool<SkillBehaviour> _behaviorPool = new VSObjectPool<SkillBehaviour>();
        protected SkillBehaviorFactory _skillBehaviorFactory;

        public ISkill Skill => _skill;
        protected Skill _skill { get; set; }
        private IDamager _damager;

        protected Dictionary<Type, SkillImproveHelper> _skillImprovers = new Dictionary<Type, SkillImproveHelper>()
        {
            {typeof(CooldownDecreaseFeature),new CooldownDecreaser() },
            {typeof(SizeIncreaseFeature),new SizeIncreaser() },
            {typeof(DamageIncreaseFeature),new DamageIncreaser() },
            {typeof(CountIncreaseFeature),new CountIncreaser() },
        };

        public ActiveSkillController(Skill a_skill, IDamager a_damager)
        {
            _damager = a_damager;
            _skill = a_skill;
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
            _damager.Damage(a_gameobject.GetHashCode(), _skill.Damage);
        } 
    }
}