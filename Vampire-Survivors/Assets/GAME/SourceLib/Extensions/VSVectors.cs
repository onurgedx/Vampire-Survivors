
using UnityEngine;

namespace VampireSurvivors.Lib.Basic.Extension.Vectors
{

    public static class VSVectors
    { 
        public static Vector3 RandomPosition(this Vector3 a_originPosition,float a_minimumDistance, float a_maximumDistance)
        {
            float distanceX = UnityEngine.Random.Range(a_minimumDistance, a_maximumDistance);
            float distanceY = UnityEngine.Random.Range(a_minimumDistance, a_maximumDistance);
            float xSign = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
            float ySign = UnityEngine.Random.Range(0, 2) == 0 ? 1 : -1;
            Vector3 extraSpawnPosition = Vector3.right * distanceX * xSign + Vector3.up * distanceY * ySign;
            return a_originPosition + extraSpawnPosition;
        }

    }
}