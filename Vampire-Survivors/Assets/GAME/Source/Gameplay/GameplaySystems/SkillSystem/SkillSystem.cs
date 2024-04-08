using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem :VSSystem , ISkillRequester
    {

        public Action<GameObject,int> DamageRequest;
        public Action SkillRequested;
        public Action SkillChoosed;
        private Dictionary<string, Skill> _skills = new Dictionary<string, Skill>();
        private List<SkillController<Skill>> _currentSkills = new List<SkillController<Skill>>(); 
        private IProperty<Vector3> _playerPosition;
        private EnemyAttackSkillController _enemyAttackSkillController;
        private VSSceneManager _vSSceneManager;
        private SkillChooseFrame _skillChooseFrame;

        public SkillSystem(  IProperty<Vector3> a_playerPosition)
        { 
            _playerPosition = a_playerPosition;
            _enemyAttackSkillController = new EnemyAttackSkillController(new EnemyAttack(0.1f,1),_playerPosition);
            AddSkillController(_enemyAttackSkillController);
            _vSSceneManager = new VSSceneManager();
            Completable< GameplayUISkillChooseSceneEntry> sceneCompletable =  _vSSceneManager.LoadAdditive<GameplayUISkillChooseSceneEntry>(GameplayUISkillChooseSceneEntry.SceneName);
            sceneCompletable.Completed +=()=>{
                _skillChooseFrame = sceneCompletable.Value.SkillChooseFrame;
                _skillChooseFrame.SkillChoosed += SkillChoose;
            };
        }


        public void Unload()
        {
            _vSSceneManager.Unload<GameplayUISkillChooseSceneEntry>(GameplayUISkillChooseSceneEntry.SceneName);
        }


        private void SkillChoose()
        {
            SkillChoosed?.Invoke();
        }


        private void Damage(GameObject a_targetGameObject,int a_damage)
        {
            DamageRequest?.Invoke(a_targetGameObject, a_damage);
        }


        public void RequestSkill()
        {
            SkillRequested?.Invoke(); 
            _skillChooseFrame.ActivateChooseSkill();
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