using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class Collector 
    {
        private Transform _transform;
        private IProperty<float> _collectRange;
        private LayerMask _collectableLayer;


        public Collector(Transform a_collectTransform,Property<float> a_collectRange, LayerMask a_collectableLayer)
        {
            _transform = a_collectTransform;
            _collectRange = a_collectRange;
            _collectableLayer = a_collectableLayer;           
        }


        public Collider[] Collect()
        {
            Collider[] colliders = null;
            colliders = Physics.OverlapSphere(_transform.position, _collectRange.Value, _collectableLayer);
            
            return colliders;
        }
    }
}