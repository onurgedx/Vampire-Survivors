
using System.Collections.Generic;
using UnityEngine; 
using VampireSurvivors.Lib.Pooling;

namespace VampireSurvivors.Gameplay.UI.SkillSystem
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
            _skillChooseFrame.SkillChooseActivate += () => gameObject.SetActive(true);
            _skillChooseFrame.SkillChoosed += (_) => gameObject.SetActive(false);
        }
         

        private void CreateSkillCardBehavior(SkillCard a_skillCard)
        {
            GameObject go = Instantiate(_skillCardPrefab, _skillCardParent);
            SkillCardBehavior skillCardBehavior = go.GetComponent<SkillCardBehavior>();
            _pool.Add(skillCardBehavior);
            skillCardBehavior.gameObject.SetActive(false);
            skillCardBehavior.Init(a_skillCard);
        }
    }
}