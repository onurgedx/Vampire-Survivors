
namespace VampireSurvivors.Lib.Basic.Extension.Array
{
    public static class VSArray
    {
        public static T Random<T>(this T[] a_array)
        {
            return a_array[UnityEngine.Random.Range(0, a_array.Length)];
        }

    }
}
