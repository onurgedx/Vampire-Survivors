
using UnityEngine;

namespace VampireSurvivors.Gameplay.Layer
{

    public class Layers 
    {
        public static int EnemyLayer = 10;
        public static int EnemyLayerMask = (int) Mathf.Pow(2, EnemyLayer);

        public static int PlayerLayer = 9;
        public static int PlayerLayerMask = (int) Mathf.Pow(2, PlayerLayer);

        public static int ChestLayer = 6;
        public static int ChestLayerMask = (int)Mathf.Pow(2, ChestLayer);


        public static int ManaLayer = 8;
        public static int ManaLayerMask = (int)Mathf.Pow(2, ManaLayer);
        
        
        public static int HealLayer = 7;
        public static int HealLayerMask = (int)Mathf.Pow(2, HealLayer);

        
    }
}
