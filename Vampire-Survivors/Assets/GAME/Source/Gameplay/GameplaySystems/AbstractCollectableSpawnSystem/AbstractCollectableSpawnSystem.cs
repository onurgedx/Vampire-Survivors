using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Basic.Properties;
using VampireSurvivors.Lib.Record;
using VampireSurvivors.Update;
namespace VampireSurvivors.Gameplay.Systems
{
    /// <summary>
    /// Manages Collectables' Collectting and Spawning Process
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractCollectableSpawnSystem<T> :VSSystem where T :Collectable 
    {
        public IProperty<float> CollectableRange => _collectRange;
        protected Collector _collector;
        protected CollectableSpawner _spawner;
        protected IRecorder<GameObject,Collectable> _collectableRecorder;
        protected Property<float> _collectRange { get; set; }
        protected Transform _parentTransform;
        protected IProperty<Vector3> _originPosition;
        protected List<T> _activeCollectables = new List<T>();
        protected int _activeCollectableCount = 0;
        protected int _maxActiveCollectableCount = 1; 
        protected VSTimerCounter _vsTimeCounter;


        protected AbstractCollectableSpawnSystem(IRecorder<GameObject, Collectable> a_recorder,
                                                 ICollectorAdder a_collectorAdder,
                                                 IProperty<Vector3> a_originTransform,
                                                 LayerMask a_collectableLayer,
                                                 Transform a_collectableParentTransform)
        {
            _collectableRecorder = a_recorder;
            _collectRange = new Property<float>(1);
            _parentTransform = a_collectableParentTransform;
            _originPosition = a_originTransform;
            _collector = new Collector(_originPosition, _collectRange, a_collectableLayer);
            _collector.OnCollect += OnCollected;
            a_collectorAdder.AddCollector(_collector);
            CreateSpawner();
        }


        public override void Update()
        {
            base.Update();
            Process();
        }
        

        protected virtual void Process()
        {
            if (_activeCollectableCount >= _maxActiveCollectableCount)
            {
                return;
            } 
            if (_vsTimeCounter.Process())
            { 
                Spawn();
            }
        }


        protected void Spawn(Type type = null)
        {
            T collectable = _spawner.Spawn(type) as T;
            if (collectable != null)
            {
                OnCreated(collectable);
            }
        }


        protected abstract void OnCollected(Collectable a_collectable);


        protected abstract void OnCreated(T a_collectabe);


        protected abstract void CreateSpawner();        
    }    
}
