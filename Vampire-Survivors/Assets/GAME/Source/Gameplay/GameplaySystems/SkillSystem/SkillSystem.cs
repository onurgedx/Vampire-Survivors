using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.UI.SkillSystem;
using VampireSurvivors.Gameplay.Units;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Extension.Lists;
using VampireSurvivors.Lib.Basic.Properties; 

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    /// <summary>
    /// Create and Controls Player Skills
    /// </summary>
    public class SkillSystem : VSSystem, ISkillRequester
    { 
        public Action SkillRequested;
        public Action SkillChoosed;
        private Dictionary<string, SkillControllerFactory> _skillControllerFactories = new Dictionary<string, SkillControllerFactory>();
        private Dictionary<string, int> _skillLevels = new Dictionary<string, int>();
        private Dictionary<string, SkillController> _currentSkillControllers = new Dictionary<string, SkillController>();

        private SkillChooseFrame _skillChooseFrame;
        private Dictionary<string, SkillData> _skillDatas = new Dictionary<string, SkillData>();
        private List<string> _requestableSkills = new List<string>();
        


        public SkillSystem(IProperty<Vector3> a_playerPosition,
                           IProperty<Vector3> a_playerDirection,
                           SkillChooseFrame a_skillChooseFrame,
                           SkillData[] a_skillDatas,
                           PlayerUnit a_playerUnit,
                           IDamager a_damager)
        {

            foreach (SkillData skillData in a_skillDatas)
            {
                _skillDatas.Add(skillData.name, skillData);
                _requestableSkills.Add(skillData.name);
            }
            CreateFactories(a_playerPosition, a_playerDirection, a_playerUnit,a_damager );
            _skillChooseFrame = a_skillChooseFrame;
            _skillChooseFrame.SkillChoosed += SkillChoose;
        }


       

        private void SkillChoose(string a_id)
        {
            SkillChoosed?.Invoke();
            if (_skillLevels.ContainsKey(a_id))
            {
                LevelUpSkill(a_id);
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
                SkillController skillController = factory.Create(); 
                AddSkillController(a_id, skillController);
                _skillLevels.Add(a_id,0);
            }
        }


        private void LevelUpSkill(string a_id)
        {
            if (_currentSkillControllers.TryGetValue(a_id, out SkillController skillController))
            {
                int level = _skillLevels[a_id];
                SkillData skillData = _skillDatas[a_id];
                SkillLevelImprovements skillLevel = skillData.Levels[level];
                skillController.LevelUp(skillLevel.Improvements);  
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
            List<string> skillIds = _requestableSkills.RandomListInList(requestedSkillCount);
            int[] skillLevels = new int[requestedSkillCount];
            int indexCounter = 0;
            foreach (string skillId in skillIds)
            {
                int skillLevel = 0;
                if (_skillLevels.TryGetValue(skillId, out skillLevel))
                {
                    skillLevel++;
                }
                skillLevels[indexCounter] = skillLevel;
                indexCounter++;
            }
            _skillChooseFrame.ActivateChooseSkill(skillIds.ToArray(), skillLevels);
        }


        public override void Update()
        {
            base.Update();
            foreach (SkillController skillController in _currentSkillControllers.Values)
            {
                if (skillController is ActiveSkillController activeSkillController)
                {
                    activeSkillController.Update();
                }
            }
        }
         

        private void AddSkillController(string a_id, SkillController a_skillController)
        {
            _currentSkillControllers.Add(a_id, a_skillController); 
        }


        private void CreateFactories(IProperty<Vector3> a_playerPosition, IProperty<Vector3> a_playerDirection, PlayerUnit a_playerUnit, IDamager a_damager)
        {
            ActiveSkillFactory activeSkillFactory = new ActiveSkillFactory();

            _skillControllerFactories.Add(Keys.Skills.Knife, new KnifeControllerFactory(a_damager,
                                                                                        _skillDatas[Keys.Skills.Knife].SkillBeginningData,
                                                                                        a_playerPosition,
                                                                                        a_playerDirection,
                                                                                        activeSkillFactory));

            _skillControllerFactories.Add(Keys.Skills.MagicBolt, new MagicBoltControllerFactory(a_damager,
                                                                                                _skillDatas[Keys.Skills.MagicBolt].SkillBeginningData,
                                                                                                a_playerPosition,
                                                                                                activeSkillFactory));

            _skillControllerFactories.Add(Keys.Skills.SpikeFloor, new SpikeFloorControllerFactory(a_damager,
                                                                                                  _skillDatas[Keys.Skills.SpikeFloor].SkillBeginningData,
                                                                                                  a_playerPosition,
                                                                                                  activeSkillFactory));

            _skillControllerFactories.Add(Keys.Skills.PlayerMaxHP, new PlayerMaxHPControllerFactory(a_playerUnit.Health, _skillDatas[Keys.Skills.PlayerMaxHP].SkillBeginningData));
            _skillControllerFactories.Add(Keys.Skills.PlayerSpeed, new PlayerSpeedControllerFactory(a_playerUnit.MovementSpeed, _skillDatas[Keys.Skills.PlayerSpeed].SkillBeginningData));
        }

    }
}