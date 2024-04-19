using System;
using UnityEngine;
using VampireSurvivors.Gameplay.Units;

namespace VampireSurvivors.Gameplay.Systems.CraftingSys
{
    [Serializable]
    public class WaveData
    {
        public EnemyData[] EnemyDatas => _enemyDatas;

        [SerializeField] private EnemyData[] _enemyDatas = new EnemyData[] { };
    }

    [Serializable]
    public class EnemyData
    {
        public UnitData Data => _unitData;
        [SerializeField] private UnitData _unitData;

        public int Count => _count;
        [SerializeField] private int _count;
    }
}