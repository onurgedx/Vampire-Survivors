using System;
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Gameplay.UI.SkillSystem;
using VampireSurvivors.Lib.Basic.Completables;
using VampireSurvivors.Lib.Basic.Extension.Array;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem :VSSystem , ISkillRequester
    {

        public Action<GameObject,int> DamageRequest;
        public Action SkillRequested;
        public Action SkillChoosed;
        private Dictionary<string, int> _skillLevels = new Dictionary<string, int>();
        private List<SkillController > _currentSkills = new List<SkillController >(); 
        private IProperty<Vector3> _playerPosition; 
        private VSSceneManager _vSSceneManager;
        private SkillChooseFrame _skillChooseFrame;


        public SkillSystem(IProperty<Vector3> a_playerPosition,IProperty<Vector3> a_playerDirection)
        { 
            _playerPosition = a_playerPosition; 
            AddSkillController( new MagicBoltController(_playerPosition));
            AddSkillController( new SpikeFloorController(_playerPosition));
            AddSkillController( new KnifeController(_playerPosition, a_playerDirection));
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


        private void SkillChoose(string a_id) 
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
            int requestedSkillCount = 2;
            string[] skillIds = Keys.Skills.SkillArray.RandomInArray(requestedSkillCount);
            int[] skillLevels =new int[requestedSkillCount];
            int indexCounter = 0;
            foreach (string skillId in skillIds)
            {
                int skillLevel = 0;
               if( !_skillLevels.TryGetValue(skillId, out skillLevel))
                {
                    _skillLevels.Add(skillId, skillLevel);
                }
                skillLevels[indexCounter] = skillLevel;
                indexCounter++;
            }
            _skillChooseFrame.ActivateChooseSkill(skillIds, skillLevels);
        }
                

        public override void Update()
        {
            base.Update();
            foreach (SkillController skillController in _currentSkills)
            {
                skillController.Update();
            }
        }


        private void AddSkillController(SkillController  a_skillController)
        {
            _currentSkills.Add(a_skillController);
            a_skillController.RunOnSkillImpact( Damage);
        }


        private void RemoveSkillController(SkillController a_skillController)
        { 
            _currentSkills.Remove(a_skillController);
        }        
    }
}