using System;
using UnityEngine;
using VampireSurvivors.Translators;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.UI
{

    public class SkillCard
    {
        public Action Updated;
        public Action Choosed;
        public IProperty<Sprite> Icon=>_iconSprite;
        private Property<Sprite> _iconSprite;

        public IProperty<string> Name => _name;
        private Property<string> _name;

        public IProperty<string> Level => _level;
        private Property<string> _level;

        public IProperty<string> Description => _description;
        private Property<string> _description;

        private const string _iconCatagoryExtra = ".Icon";

        public SkillCard()
        {
            _iconSprite = new Property<Sprite>(null);
            _name = new Property<string>("Skill");
            _level = new Property<string>("Level");
            _description = new Property<string>("description");
        }


        public void Update(string a_skillId, int a_level)
        {
            AsyncOperationHandle<Sprite> icon = Addressables.LoadAssetAsync<Sprite>(a_skillId + _iconCatagoryExtra);
            icon.Completed += (_) =>
            {
                _iconSprite.SetValue(icon.Result);
                _name.SetValue(LanguageTranslator.Translate(a_skillId));
                _description.SetValue ( LanguageTranslator.Translate(a_skillId + "." + a_level.ToString()));
                _level.SetValue("Level " + a_level.ToString());
                Updated?.Invoke();
            };
        }


        public void Choose()
        {
            Choosed?.Invoke();
        }

        public void Show()
        {

        }

        public void Hide()
        {

        }
    }
}