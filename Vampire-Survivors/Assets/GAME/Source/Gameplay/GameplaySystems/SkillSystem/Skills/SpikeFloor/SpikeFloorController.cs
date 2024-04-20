using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SpikeFloorController : SkillController
    {
        private IProperty<Vector3> _startPosition;
        public SpikeFloorController(Skill a_skill,int a_skillLevelHash, IProperty<Vector3> a_startPosition):base(a_skill, a_skillLevelHash)
        { 
            _startPosition = a_startPosition;
            AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(Keys.Skills.SpikeFloor + AddressableSources.Keys.AddressableKeys.Suffix.Prefab);
            asset.Completed += Init;
        }
         

        public override void Play(SkillBehaviour a_skillBehavior)
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