
using System.Collections.Generic; 

namespace VampireSurvivors.Lib.Basic.Extension.Array
{
    public static class VSArray
    {
        public static T Random<T>(this T[] a_array)
        {
            return a_array[UnityEngine.Random.Range(0, a_array.Length)];
        }


        public static T[] RandomInArray<T>(this T[] a_array, int a_count)
        {
            List<T> randomList = new List<T>();
            if (a_count <= a_array.LongLength)
            {
                for (int i = 0; i < a_count; i++)
                {
                    randomList.Add(a_array.Random());
                }
                return randomList.ToArray();;
            }
            return a_array;
        }

    }
}
