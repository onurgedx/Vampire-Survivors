
using UnityEngine;
using VampireSurvivors.Gameplay.Systems.CollectionSys;

public abstract class CollectableFactory 
{
    public abstract (ICollectable, GameObject) Create(Vector3 a_position);
}
