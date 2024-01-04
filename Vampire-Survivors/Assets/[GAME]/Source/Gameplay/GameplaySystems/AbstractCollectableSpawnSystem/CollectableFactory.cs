
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

public abstract class CollectableFactory 
{
    protected GameObject _prefab;
    protected Transform _parent;
    public CollectableFactory(GameObject a_manaPrefab, Transform a_parent)
    {
        _prefab = a_manaPrefab;
        _parent = a_parent;
    }

    public abstract (ICollectable, GameObject) Create(Vector3 a_position);

}
