using System;
using System.Collections.Generic;
using UnityEngine;

namespace VampireSurvivors.Gameplay.Systems.CraftingSys
{
    [CreateAssetMenu(fileName = "EnemyWaveData", menuName = "Data/Level/EnemyWaves", order = 1)]
    [Serializable]
    public class EnemyWaveDatas : ScriptableObject
    {
        public List<WaveData> WaveDatas => _waveDatas;
        [SerializeField] private List<WaveData> _waveDatas= new List<WaveData>(); 
    }


}