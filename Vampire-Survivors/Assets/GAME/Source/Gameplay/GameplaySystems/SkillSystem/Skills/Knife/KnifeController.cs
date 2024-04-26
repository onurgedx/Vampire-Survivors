using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Extension.Vectors;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class KnifeController : ActiveSkillController
    {
        private IProperty<Vector3> _startPosition;
        private IProperty<Vector3> _direction;
         

        public KnifeController(Skill a_skill, IDamager a_damager, IProperty<Vector3> a_startPosition, IProperty<Vector3> a_direction):base(a_skill, a_damager)
        { 
            _direction = a_direction;
            _startPosition = a_startPosition;
            AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(Keys.Skills.Knife + AddressableSources.Keys.AddressableKeys.Suffix.Prefab);
            asset.Completed += Init;

        }
         

        protected override void Play(SkillBehaviour a_skillBehavior)
        {
            KnifeBehavior behavior = a_skillBehavior as KnifeBehavior;
            Vector3 startPos = VSVectors.RandomPosition(_startPosition.Value, 0, 0.4f);
            behavior.Settings(_direction.Value, startPos); 
            behavior.Play();
        }

         

        private void Init(AsyncOperationHandle<GameObject> a_asset)
        {
            _skillBehaviorFactory = new KnifeBehaviorFactory(a_asset.Result, _startPosition);
        }
    }
}