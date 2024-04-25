using System.Collections.Generic; 
namespace VampireSurvivors.Lib.Basic.Extension.Array
{
    public static class VSArray
    {
        /// <summary>
        /// Returns a random member in array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a_array"></param>
        /// <returns></returns>
        public static T Random<T>(this T[] a_array)
        {
            return a_array[UnityEngine.Random.Range(0, a_array.Length)];
        }

        /// <summary>
        /// Returns a random array from given array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a_array"></param>
        /// <param name="a_count"></param>
        /// <returns></returns>
        public static T[] RandomInArray<T>(this T[] a_array, int a_count)
        {
            List<T> randomList = new List<T>();
            List<T> copyArray = new List<T>();
            copyArray.AddRange(a_array);            
            if (a_count <= a_array.LongLength)
            {
                for (int i = 0; i < a_count; i++)
                {
                    T item = copyArray[UnityEngine.Random.Range(0, copyArray.Count)];
                    randomList.Add(item);
                    copyArray.Remove(item);
                }
                return randomList.ToArray();;
            }
            return a_array;
        }



        /// <summary>
        /// Returns Whether given array has <typeparamref name="K"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="a_array"></param>
        /// <returns></returns>
        public static bool HasTypeOf<T,K> (this T[] a_array)
        {
            foreach (T member in a_array)
            {
                if (member is K )
                {
                    return true;
                }
            }
            return false;
        }
         

    }
}
