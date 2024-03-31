
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.UI
{
    public class SkillChooseFrameBehavior : MonoBehaviour
    {

        [SerializeField] private GameObject _skillCardPrefab;
        [SerializeField] private Transform _skillCardParent;
        private VSObjectPool<SkillCardBehavior> _pool = new VSObjectPool<SkillCardBehavior>();
        private SkillChooseFrame _skillChooseFrame;

        public void Init(SkillChooseFrame a_skillChooseFrame)
        {
            _skillChooseFrame = a_skillChooseFrame;
            _skillChooseFrame.SkillCardCreated += CreateSkillCardBehavior;
            _skillChooseFrame.SkillChooseActivate += UpdateCards;
            _skillChooseFrame.SkillChooseDeactivate += () => gameObject.SetActive(false);

        }


        public void UpdateCards()
        {
            gameObject.SetActive(true);
            foreach (SkillCard skillCard in _skillChooseFrame.SkillCards)
            {
                if (_pool.TryRetrieve(out SkillCardBehavior skillCardBehavior))
                {
                    skillCardBehavior.gameObject.SetActive(true);
                }
                else
                {
                    GameObject go = Instantiate(_skillCardPrefab, _skillCardParent);
                    skillCardBehavior = go.GetComponent<SkillCardBehavior>();
                    _pool.Add(skillCardBehavior);
                    skillCardBehavior.gameObject.SetActive(true);
                }

                skillCardBehavior.Init(skillCard);

            }


        }

        private void CreateSkillCardBehavior(SkillCard a_skillCard)
        {
            GameObject go = Instantiate(_skillCardPrefab, _skillCardParent);
            SkillCardBehavior skillCardBehavior = go.GetComponent<SkillCardBehavior>();
            _pool.Add(skillCardBehavior);
            skillCardBehavior.gameObject.SetActive(true);
            skillCardBehavior.Init(a_skillCard);
        }



    }
}