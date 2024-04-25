namespace VampireSurvivors.Translators
{
    public static class LanguageTranslator
    {
        public enum Languages
        {
            English,
            Turkish
        }
     
        public static Languages CurrentLanguage = Languages.English;


        /// <summary>
        /// Translates <paramref name="a_key"/> to selected language
        /// </summary>
        /// <param name="a_key"></param>
        /// <returns></returns>
        public static string Translate(string a_key )
        {
            switch (CurrentLanguage)
            {
                case Languages.English:
                    return a_key;                     
                case Languages.Turkish:
                    return a_key;                      
            }
            return a_key;
        }
    }
}