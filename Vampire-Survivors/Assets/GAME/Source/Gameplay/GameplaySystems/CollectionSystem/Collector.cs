using System;
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class Collector
    {
        public Action<Collectable> OnCollect;

        private IProperty<Transform> _transform;
        private IProperty<float> _collectRange;
        private LayerMask _collectableLayer;


        public Collector(IProperty<Transform> a_collectTransform, Property<float> a_collectRange, LayerMask a_collectableLayer)
        {
            _transform = a_collectTransform;
            _collectRange = a_collectRange;
            _collectableLayer = a_collectableLayer;
        }


        public Collider2D[] Collect()
        {
            Vector2 collectPoint = _transform.Value != null ? _transform.Value.position : Vector2.one * 1231231;
            Collider2D[] colliders = Physics2D.OverlapCircleAll(collectPoint, _collectRange.Value, _collectableLayer);
            return colliders;
        }


        public void Collect(Collectable a_collectable)
        {
            a_collectable.Collect();
            OnCollect?.Invoke(a_collectable);
        }

    }
}