
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;
using VampireSurvivors.Lib.Pooling;

public abstract class CollectableFactory 
{
    protected GameObject _prefab;
    protected Transform _parent;
    protected VSObjectPool<Transform> _pool= new VSObjectPool<Transform>();

    public CollectableFactory(GameObject a_prefab, Transform a_parent)
    {
        _prefab = a_prefab;
        _parent = a_parent;
    }


    public (ICollectable, GameObject) Create(Vector3 a_position)
    {
        ICollectable collectable = RetriveCollectable();
        if (_pool.TryRetrieve(out GameObject collectableGameObject))
        {
            collectableGameObject.transform.position = a_position;
        }
        else
        {
            //collectableGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, _parent );
            collectableGameObject = GameObject.Instantiate(_prefab, a_position, Quaternion.identity, null );
            _pool.Add(collectableGameObject.transform);
        }
        collectableGameObject.SetActive(true);

        return (collectable, collectableGameObject);
    }


    protected abstract ICollectable RetriveCollectable();
}
