using System.IO;
using System.Net;
using GoogleTranslateNet;

namespace AtlusRandomizer
{
    public static class Translator
    {
        public static void Translate(string[] array, params Language[] languages)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = Translate(array[i], languages);
        }

        public static string Translate(string text, params Language[] languages)
        {
            return BadTranslator.Translate(text, new string[] { "ja", "ru", "en" });
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
