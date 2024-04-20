using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.UI.SkillSystem;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Lists;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem : VSSystem, ISkillRequester
    {

        public Action<int, int> DamageRequest;
        public Action SkillRequested;
        public Action SkillChoosed;
        private Dictionary<string, SkillControllerFactory> _skillControllerFactories = new Dictionary<string, SkillControllerFactory>();
        private Dictionary<string, int> _skillLevels = new Dictionary<string, int>();
        private Dictionary<string, SkillController> _currentSkills = new Dictionary<string, SkillController>();
        private SkillChooseFrame _skillChooseFrame;
        private Dictionary<string, SkillData> _skillDatas = new Dictionary<string, SkillData>();

        private List<string> _requestableSkills = new List<string>();


        public SkillSystem(IProperty<Vector3> a_playerPosition, IProperty<Vector3> a_playerDirection, SkillChooseFrame a_skillChooseFrame, SkillData[] a_skillDatas)
        {
            foreach (SkillData skillData in a_skillDatas)
            {
                _skillDatas.Add(skillData.name, skillData);
                _requestableSkills.Add(skillData.name);
            }
            CreateFactories(a_playerPosition, a_playerDirection);
            _skillChooseFrame = a_skillChooseFrame;
            _skillChooseFrame.SkillChoosed += SkillChoose;
        }


        private void CreateFactories(IProperty<Vector3> a_playerPosition, IProperty<Vector3> a_playerDirection)
        {
            _skillControllerFactories.Add(Keys.Skills.Knife, new KnifeControllerFactory(a_playerPosition, a_playerDirection));
            _skillControllerFactories.Add(Keys.Skills.MagicBolt, new MagicBoltControllerFactory(a_playerPosition));
            _skillControllerFactories.Add(Keys.Skills.SpikeFloor, new SpikeFloorControllerFactory(a_playerPosition));
        }


        private void SkillChoose(string a_id)
        {
            SkillChoosed?.Invoke();
            if (_skillLevels.TryGetValue(a_id, out int level))
            {
                LevelUpSkill(a_id);
                _skillLevels[a_id] = level + 1;
            }
            else
            {
                CreateSkill(a_id);
            }
        }


        private void CreateSkill(string a_id)
        {
            if (_skillControllerFactories.TryGetValue(a_id, out SkillControllerFactory factory))
            {
                SkillData skilData = _skillDatas[a_id];
                SkillLevel skillLevel = skilData.Levels[0];
                Skill skill = new Skill(skillLevel.Cooldown, skillLevel.Duration ); 
                AddSkillController(a_id, factory.Create(skill, skillLevel.GetHashCode()));
                _skillLevels.Add(a_id, 1); 
            }
        }


        private void LevelUpSkill(string a_id)
        {
            if (_currentSkills.TryGetValue(a_id, out SkillController skillController))
            {
                int level = _skillLevels[a_id];
                SkillData skillData = _skillDatas[a_id];
                SkillLevel skillLevel = skillData.Levels[level]; 
                skillController.LevelUp(skillLevel.GetHashCode(),skillLevel.Cooldown,skillLevel.Duration);
                level++;
                _skillLevels[a_id] = level;
                if (level >= skillData.Levels.Length)
                {
                    _requestableSkills.Remove(a_id);
                }
            }
        }
        

        public void RequestSkill()
        {
            SkillRequested?.Invoke();
            int requestedSkillCount = 2;
            List<string> skillIds = _requestableSkills.RandomInList(requestedSkillCount);
            int[] skillLevels = new int[requestedSkillCount];
            int indexCounter = 0;
            foreach (string skillId in skillIds)
            {
                int skillLevel = 0;
                if (!_skillLevels.TryGetValue(skillId, out skillLevel))
                {
                }
                skillLevels[indexCounter] = skillLevel + 1;
                indexCounter++;
            }
            _skillChooseFrame.ActivateChooseSkill(skillIds.ToArray(), skillLevels);
        }


        public override void Update()
        {
            base.Update();
            foreach (SkillController skillController in _currentSkills.Values)
            {
                skillController.Update();
            }
        }


        private void Damage(int a_damageSource, int a_targetGameObject)
        {
            DamageRequest?.Invoke(a_damageSource, a_targetGameObject);
        }


        private void AddSkillController(string a_id, SkillController a_skillController)
        {
            _currentSkills.Add(a_id, a_skillController);
            a_skillController.RunOnSkillImpact( Damage);
        }


        private void RemoveSkillController(string a_id)
        {
            _currentSkills.Remove(a_id);
        }
    }
}