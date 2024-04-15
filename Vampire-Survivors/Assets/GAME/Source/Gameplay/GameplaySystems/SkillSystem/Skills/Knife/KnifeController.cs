using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeController : SkillController
    {
        private IProperty<Vector3> _startPosition;
        private IProperty<Vector3> _direction;
        public KnifeController(IProperty<Vector3> a_startPosition, IProperty<Vector3> a_direction)
        {
            LevelTypes = KnifeLevels.Levels;
            _skill = new Skill(3, 45);
            _direction = a_direction;
            _startPosition = a_startPosition;
            AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(Keys.Skills.Knife + AddressableSources.Keys.AddressableKeys.Suffix.Prefab);
            asset.Completed += Init;

        }

        public override void LevelUp()
        {
            _level++;            

        }


        public override void Play(SkillBehaviour a_skillBehavior)
        {
            KnifeBehavior behavior = a_skillBehavior as KnifeBehavior;
            behavior.Settings(_direction.Value, _startPosition.Value);
            behavior.Play();
        }


        private void Init(AsyncOperationHandle<GameObject> a_asset)
        {
            _skillFactory = new KnifeBehaviorFactory(a_asset.Result, _startPosition);
        }
    }
}