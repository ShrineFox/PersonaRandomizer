using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GTranslate.Translators;

namespace AtlusRandomizer
{
    public static class BadTranslator
    {
        private static readonly Dictionary<string, string> sTranslationCache = new Dictionary<string, string>( 1024 );

        public static void Translate( string[] array, out string[] translated )
        {
            translated = new string[array.Length];
            List<string> sTranslationLanguages = new List<string> { "ja", "ru", "en" };
            
            for (int i = 0; i < array.Length; i++)
                translated[i] = Translate(array[i], sTranslationLanguages.ToArray());
        }

        public static string Translate( string text, string[] sTranslationLanguages)
        {
            if ( !sTranslationCache.TryGetValue(text, out var translatedText))
            {
                translatedText = text;

                foreach ( var lang in sTranslationLanguages )
                    translatedText = Translate( translatedText, lang );

                translatedText = WebUtility.HtmlDecode( translatedText );

                sTranslationCache[text] = translatedText;
                Console.WriteLine( $"{text} -> {translatedText}" );
            }

            return translatedText;
        }

        public static string Translate( string text, string targetLanguage )
        {
            var translator = new GoogleTranslator();

            var result = translator.TranslateAsync(text, targetLanguage);

            return result.Result.Translation;
        }
    }
}
