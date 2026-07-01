using System.IO;
using System.Net;
using GoogleTranslateNet;

namespace AtlusRandomizer
{
    public static class Translator
    {
        public static void Translate(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = Translate(array[i]);
        }

        public static string Translate(string text)
        {
            return BadTranslator.Translate(text);
        }
    }
}
