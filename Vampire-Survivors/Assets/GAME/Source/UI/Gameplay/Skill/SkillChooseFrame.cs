using System;
using System.Collections.Generic;

namespace VampireSurvivors.Gameplay.UI
{

    public class SkillChooseFrame
    {

        public Action SkillChooseActivate;
        public Action SkillChooseDeactivate;

        public Action<SkillCard> SkillCardCreated;

        public List<SkillCard> SkillCards = new List<SkillCard>() {  };


        public SkillCard GenerateSkillCard()
        {
            SkillCard skillCard = new SkillCard();
            SkillCards.Add(skillCard);
            SkillCardCreated?.Invoke(skillCard);
            skillCard.Choosed += DeactivateChooseSkill;
            return skillCard;
        }
         
        public void DeactivateChooseSkill()
        {
            SkillChooseDeactivate?.Invoke();
        }
        
        public void ActivateChooseSkill()
        {
            string[] a_skillIds = new string[] { "Skill.MagicBolt" , "Skill.MagicBolt", "Skill.MagicBolt" };
            int neededCardCount = a_skillIds.Length - SkillCards.Count;
            if (neededCardCount > 0)
            {
                for (int i = 0; i < neededCardCount; i++)
                {
                    GenerateSkillCard();
                }
            }
            for (int i = 0; i < SkillCards.Count; i++)
            {
                if (i < a_skillIds.Length)
                {
                    SkillCards[i].Update(a_skillIds[i], 1);
                    SkillCards[i].Show();
                }
                else
                {
                    SkillCards[i].Hide();
                }
            }
            SkillChooseActivate.Invoke();


        }

    }
}