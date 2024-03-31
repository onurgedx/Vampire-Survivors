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