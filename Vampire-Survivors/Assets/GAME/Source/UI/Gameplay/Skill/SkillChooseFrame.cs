using System;
using System.Collections.Generic;
namespace VampireSurvivors.Gameplay.UI.SkillSystem
{

    public class SkillChooseFrame
    {

        public Action SkillChooseActivate;
        public Action<string> SkillChoosed;

        public Action<SkillCard> SkillCardCreated;

        public List<SkillCard> SkillCards = new List<SkillCard>() { };
        public SkillCard GenerateSkillCard()
        {
            SkillCard skillCard = new SkillCard();
            SkillCardCreated?.Invoke(skillCard);
            skillCard.Choosed += () => Choose(skillCard.Id);
            return skillCard;
        }

        private void Choose(string a_id)
        {            
            SkillChoosed?.Invoke(a_id);
        }

        public void ActivateChooseSkill(string[] a_skillIds, int[] a_levels)
        {
            int neededCardCount = a_skillIds.Length - SkillCards.Count;
            if (neededCardCount > 0)
            {
                for (int i = 0; i < neededCardCount; i++)
                {
                    SkillCards.Add(GenerateSkillCard());
                }
            }
            for (int k = 0; k < SkillCards.Count; k++)
            {
                if (k < a_skillIds.Length)
                {
                    SkillCards[k].Update(a_skillIds[k], a_levels[k]);
                    SkillCards[k].Show();
                }
                else
                {
                    SkillCards[k].Hide();
                }
            }
            SkillChooseActivate.Invoke();
        }
    }
}