
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.Gameplay.UI
{
    public class SkillCardBehavior : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private Button _button;

        private SkillCard _skillCard;


        public void Init(SkillCard a_skillCard)
        {
            if (_skillCard != null)
            {
                _button.onClick.RemoveListener( _skillCard.Choose);
                _skillCard.Updated -= UpdateValues;
            }
            _skillCard = a_skillCard;
            _skillCard.Updated += UpdateValues;
            _button.onClick.AddListener( _skillCard.Choose);
        }


        private void UpdateValues()
        {
            _icon.sprite = _skillCard.Icon.Value;
            _name.text = _skillCard.Name.Value;
            _level.text = _skillCard.Level.Value;
            _description.text = _skillCard.Description.Value;
        }
    }
}