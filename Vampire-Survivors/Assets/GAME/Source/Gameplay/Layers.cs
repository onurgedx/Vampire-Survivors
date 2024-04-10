
using UnityEngine;

namespace VampireSurvivors.Gameplay.Layer
{

    public class Layers 
    {
        public static int EnemyLayer = 10;
        public static int EnemyLayerMask = (int) Mathf.Pow(2, EnemyLayer);
        public static int PlayerLayerMask = (int) Mathf.Pow(2, 9);

    }
}
