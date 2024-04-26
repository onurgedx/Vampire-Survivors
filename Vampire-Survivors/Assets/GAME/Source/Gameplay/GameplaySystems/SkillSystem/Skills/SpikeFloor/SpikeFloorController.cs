using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Gameplay.Systems.BattleSys;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorController : ActiveSkillController
    {
        private IProperty<Vector3> _startPosition;
        public SpikeFloorController(Skill a_skill,IDamager a_damager, IProperty<Vector3> a_startPosition):base(a_skill, a_damager)
        { 
            _startPosition = a_startPosition;
            AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(Keys.Skills.SpikeFloor + AddressableSources.Keys.AddressableKeys.Suffix.Prefab);
            asset.Completed += Init;
        }
         
        protected override void Play(SkillBehaviour a_skillBehavior)
        {
            SpikeFloorBehavior behavior = a_skillBehavior as SpikeFloorBehavior;
            behavior.Settings(_startPosition.Value);
            a_skillBehavior.Play();
        }


        private void Init(AsyncOperationHandle<GameObject> a_asset)
        {
            _skillBehaviorFactory = new SpikeFloorBehaviorFactory(a_asset.Result, _startPosition);
        }
    }
}