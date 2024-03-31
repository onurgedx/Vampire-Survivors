using System;
using System.Collections.Generic;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Gameplay.UI;
using VampireSurvivors.Lib.Basic.Extension.Array;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillSystem :VSSystem , ISkillRequester
    {
        public Action SkillRequested;
        private Dictionary<string, Skill> _skills = new Dictionary<string, Skill>();
        private List<SkillController<Skill>> _currentSkills = new List<SkillController<Skill>>();
        private Damager _damager; 


        public SkillSystem(Damager a_damager )
        {
            _damager = a_damager; 

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
    }
}