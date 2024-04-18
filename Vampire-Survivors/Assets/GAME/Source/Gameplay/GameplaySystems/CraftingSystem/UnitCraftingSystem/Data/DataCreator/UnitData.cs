
using UnityEngine;
namespace VampireSurvivors.Gameplay.Units
{
    [CreateAssetMenu(fileName = "Unit", menuName = "Data/Unit/UnitData", order = 1)]
    public class UnitData : ScriptableObject
    {

        public string UnitId=> _unitId;
        [SerializeField] private string _unitId;

        public int MaxHealth=>_maxHealth;
        [SerializeField] private int _maxHealth=100;

        public float MovementSpeed => _movementSpeed;
        [SerializeField] private float _movementSpeed=1;

        public int AttackPower => _attackPower;
        [SerializeField] private int _attackPower=10;

    }
}