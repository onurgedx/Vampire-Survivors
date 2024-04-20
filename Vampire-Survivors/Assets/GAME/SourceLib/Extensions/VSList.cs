
using System.Collections.Generic;

namespace VampireSurvivors.Lib.Basic.Extension.Lists
{
    public static class VSList  
    {
        public static T Random<T>(this List<T> a_list)
        {
            return a_list[UnityEngine.Random.Range(0, a_list.Count)];
        }
        public static List<T> RandomInList<T>(this List<T>  a_list, int a_count)
        {
            List<T> randomList = new List<T>();
            List<T> copyArray = new List<T>();
            copyArray.AddRange(a_list);
            if (a_count <= a_list.Count)
            {
                for (int i = 0; i < a_count; i++)
                {
                    T item = copyArray[UnityEngine.Random.Range(0, copyArray.Count)];
                    randomList.Add(item);
                    copyArray.Remove(item);
                }
                return randomList  ;
            }
            return a_list;
        }
    }
}