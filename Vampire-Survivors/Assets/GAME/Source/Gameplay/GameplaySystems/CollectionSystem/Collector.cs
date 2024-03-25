using System;
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public class Collector
    {
        public Action<Collectable> OnCollect;

        private IProperty<Vector3> _collectPosition;
        private IProperty<float> _collectRange;
        private LayerMask _collectableLayer;


        public Collector(IProperty<Vector3> a_collectPosition, Property<float> a_collectRange, LayerMask a_collectableLayer)
        {
            _collectPosition = a_collectPosition;
            _collectRange = a_collectRange;
            _collectableLayer = a_collectableLayer;
        }


        public Collider2D[] Collect()
        {
            Vector2 collectPoint = _collectPosition.Value != null ? _collectPosition.Value : Vector2.one * 1231231;
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