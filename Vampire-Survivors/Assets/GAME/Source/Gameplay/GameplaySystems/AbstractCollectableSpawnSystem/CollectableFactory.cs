
using UnityEngine;
using VampireSurvivors.Lib.Pooling;
namespace VampireSurvivors.Gameplay.Systems.CollectionSys
{
    public abstract class CollectableFactory
    {
        protected GameObject _prefab;
        protected Transform _parent;
        protected VSObjectPool<CollectableBehavior> _pool = new VSObjectPool<CollectableBehavior>();

        public CollectableFactory(GameObject a_prefab, Transform a_parent)
        {
            _prefab = a_prefab;
            _parent = a_parent;
        }


        public (Collectable, GameObject) Create(Vector3 a_position)
        {
            Collectable collectable = RetriveCollectable();
            if (_pool.TryRetrieve(out CollectableBehavior collectableBehavior))
            {
                collectableBehavior.transform.position = a_position;
            }
            else
            {
                GameObject collectableGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent);
                collectableBehavior = collectableGameObject.GetComponent<CollectableBehavior>();
                _pool.Add(collectableBehavior);
            }
            collectableBehavior.gameObject.SetActive(true);

            if (collectableBehavior == null)
            {
                Debug.LogError("CollectableBehavior is NULL. Please add CollectableBehavior to the GameObject");
            }
            else
            {
                collectableBehavior.Init(collectable);
            }

            return (collectable, collectableBehavior.gameObject);
        }


        protected abstract Collectable RetriveCollectable();
    }

}