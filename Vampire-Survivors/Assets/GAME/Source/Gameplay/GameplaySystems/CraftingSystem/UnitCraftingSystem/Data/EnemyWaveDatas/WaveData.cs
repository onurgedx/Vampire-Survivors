using System; 
using UnityEngine;

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
        public string Name =>_name;
        [SerializeField]private string _name;

        public int Count=>_count;
        [SerializeField] private int _count;
    }
}