
using UnityEngine;
using VampireSurvivors.Lib.Basic.Properties;
namespace VampireSurvivors.Gameplay.Units
{
    public class UnitMovementData
    {
        public IProperty<float> Speed { get; private set; }
        public IProperty<Transform> Transform { get; private set; }

        public UnitMovementData(IProperty<float> a_speed, IProperty<Transform> a_transform)
        {
            Speed = a_speed;
            Transform = a_transform;
        }
    }
}