using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.UI.SkillSystem;
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem : VSSystem, ISkillRequester
    {

        public Action<GameObject, int> DamageRequest;
        public Action SkillRequested;
        public Action SkillChoosed;
        private Dictionary<string, SkillControllerFactory> _skillControllerFactories = new Dictionary<string, SkillControllerFactory>();
        private Dictionary<string, int> _skillLevels = new Dictionary<string, int>();
        private Dictionary<string, SkillController> _currentSkills = new Dictionary<string, SkillController>();
        private VSSceneManager _vSSceneManager;
        private SkillChooseFrame _skillChooseFrame;


        public SkillSystem(IProperty<Vector3> a_playerPosition, IProperty<Vector3> a_playerDirection)
        {
            CreateFactories(a_playerPosition, a_playerDirection);
            _vSSceneManager = new VSSceneManager();
            Completable<GameplayUISkillChooseSceneEntry> sceneCompletable = _vSSceneManager.LoadAdditive<GameplayUISkillChooseSceneEntry>(GameplayUISkillChooseSceneEntry.SceneName);
            sceneCompletable.RunOnCompleted(() =>
          {
              _skillChooseFrame = sceneCompletable.Value.SkillChooseFrame;
              _skillChooseFrame.SkillChoosed += SkillChoose;
          });
        }


        private void CreateFactories(IProperty<Vector3> a_playerPosition, IProperty<Vector3> a_playerDirection)
        {
            _skillControllerFactories.Add(Keys.Skills.Knife, new KnifeControllerFactory(a_playerPosition, a_playerDirection));
            _skillControllerFactories.Add(Keys.Skills.MagicBolt, new MagicBoltControllerFactory(a_playerPosition));
            _skillControllerFactories.Add(Keys.Skills.SpikeFloor, new SpikeFloorControllerFactory(a_playerPosition));
        }


        public void Unload()
        {
            _vSSceneManager.Unload<GameplayUISkillChooseSceneEntry>(GameplayUISkillChooseSceneEntry.SceneName);
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
                AddSkillController(a_id, factory.Create());
                _skillLevels.Add(a_id, 1);
            }

        }

        private void LevelUpSkill(string a_id)
        {
            if (_currentSkills.TryGetValue(a_id, out SkillController skillController))
            {
                skillController.LevelUp();
            }
        }      


        public void RequestSkill()
        {
            SkillRequested?.Invoke();
            int requestedSkillCount = 2;
            string[] skillIds = Keys.Skills.SkillArray.RandomInArray(requestedSkillCount);
            int[] skillLevels = new int[requestedSkillCount];
            int indexCounter = 0;
            foreach (string skillId in skillIds)
            {
                int skillLevel = 0;
                if (!_skillLevels.TryGetValue(skillId, out skillLevel))
                { 
                }
                skillLevels[indexCounter] = skillLevel+1;
                indexCounter++;
            }
            _skillChooseFrame.ActivateChooseSkill(skillIds, skillLevels);
        }


        public override void Update()
        {
            base.Update();
            foreach (  SkillController skillController  in _currentSkills.Values)
            {
                skillController.Update();
            }
        }


        private void Damage(GameObject a_targetGameObject, int a_damage)
        {
            DamageRequest?.Invoke(a_targetGameObject, a_damage);
        }

        private void AddSkillController(string a_id, SkillController a_skillController)
        {
            _currentSkills.Add(a_id, a_skillController);
            a_skillController.RunOnSkillImpact(Damage);
        }


        private void RemoveSkillController(string a_id)
        {
            _currentSkills.Remove(a_id);
        }
    }
}