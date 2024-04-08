using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem :VSSystem , ISkillRequester
    {

        public Action<GameObject,int> DamageRequest;
        public Action SkillRequested;
        private Dictionary<string, Skill> _skills = new Dictionary<string, Skill>();
        private List<SkillController<Skill>> _currentSkills = new List<SkillController<Skill>>(); 
        private IProperty<Vector3> _playerPosition;
        private EnemyAttackSkillController _enemyAttackSkillController;



        public SkillSystem(  IProperty<Vector3> a_playerPosition)
        { 
            _playerPosition = a_playerPosition;
            _enemyAttackSkillController = new EnemyAttackSkillController(new EnemyAttack(0.1f,1),_playerPosition);
            AddSkillController(_enemyAttackSkillController);
        }

        private void Damage(GameObject a_targetGameObject,int a_damage)
        {
            DamageRequest?.Invoke(a_targetGameObject, a_damage);
        }

        public void RequestSkill()
        {
            SkillRequested?.Invoke();
        }
                

        private void CreateSkills()
        {
             
        }


        public override void Update()
        {
            base.Update();
            foreach (SkillController<Skill> skillController in _currentSkills)
            {
                skillController.Update();
            }
        }


        private void AddSkillController(SkillController<Skill> a_skillController)
        {
            _currentSkills.Add(a_skillController);
            a_skillController.SkillImpact += Damage;
        }

        private void RemoveSkillController(SkillController<Skill> a_skillController)
        {
            a_skillController.SkillImpact -= Damage;
            _currentSkills.Remove(a_skillController);
        }


    }
}