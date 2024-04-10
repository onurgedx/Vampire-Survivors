using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;

namespace VampireSurvivors.Gameplay.Systems.SkillSys
{
    public class SkillBehaviorFactory 
    {
        private GameObject _prefab;
        private IProperty<Vector3> _startPosition;

        public SkillBehaviorFactory(GameObject a_prefab,IProperty<Vector3> a_startPosition)
        {
            _prefab = a_prefab;
            _startPosition = a_startPosition;
        }


        public virtual SkillBehaviour Create()
        {
            GameObject go = GameObject.Instantiate(_prefab, _startPosition.Value,Quaternion.identity);
            SkillBehaviour skillBehaviour = go.GetComponent<SkillBehaviour>();
            return skillBehaviour;
        }


    }
}