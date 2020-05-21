using System.Net;
using GoogleTranslateNET;

namespace AtlusRandomizer
{
    public static class Translator
    {
        private static readonly GoogleTranslate sGoogleTranslate = new GoogleTranslate("google_translate_api_key_goes_here");

        public static void Translate(string[] array, params Language[] languages)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = Translate(array[i], languages);
        }

        public static string Translate(string text, params Language[] languages)
        {
            string translatedText = text;
            for (int i = 0; i < languages.Length; i += 2)
            {
                translatedText = sGoogleTranslate.Translate(languages[i], languages[i + 1], translatedText)[0].TranslatedText;
            }

            return WebUtility.HtmlDecode(translatedText);
        }

        public static void Translate(string[] array)
        {
            Translate(array,
                Language.English, Language.Japanese,
                Language.Japanese, Language.German,
                Language.German, Language.ChineseTraditional,
                Language.ChineseTraditional, Language.Turkish,
                Language.Turkish, Language.Swahili,
                Language.Swahili, Language.English);
        }

        public static string Translate(string text)
        {
            return Translate(text,
                Language.English, Language.Japanese,
                Language.Japanese, Language.German,
                Language.German, Language.ChineseTraditional,
                Language.ChineseTraditional, Language.Turkish,
                Language.Turkish, Language.Swahili,
                Language.Swahili, Language.English);
        }
    }
}
