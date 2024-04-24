using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class MagicBoltController : ActiveSkillController 
    {
        private IProperty<Vector3> _startPosition;

        public MagicBoltController(Skill a_skill,int a_skillLevelHash,IProperty<Vector3> a_startPosition  ) : base( a_skill,a_skillLevelHash )
        {  
            _startPosition = a_startPosition;
           AsyncOperationHandle<GameObject> asset = Addressables.LoadAssetAsync<GameObject>(Keys.Skills.MagicBolt + AddressableSources.Keys.AddressableKeys.Suffix.Prefab);
           asset.Completed += Init;
        }
         

        protected override void Play(SkillBehaviour a_skillBehavior)
        {
            MagicBoltBehavior behavior = a_skillBehavior as MagicBoltBehavior;
            Vector3 direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);    
            
            behavior.Settings(_startPosition.Value, direction.normalized);
            a_skillBehavior.Play();
        }


        private void Init(AsyncOperationHandle<GameObject> a_asset)
        {
            _skillBehaviorFactory = new MagicBoltBehaviorFactory(a_asset.Result, _startPosition); 
        }
    }
}