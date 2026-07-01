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
        public static string[] languages;
        public static string translationEngine;

        public static void Translate( string[] array, out string[] translated )
        {
            translated = new string[array.Length];
            
            for (int i = 0; i < array.Length; i++)
                translated[i] = Translate(array[i]);
        }

        public static string Translate( string text)
        {
            if ( !sTranslationCache.TryGetValue(text, out var translatedText))
            {
                translatedText = text;

                foreach ( var lang in languages)
                    translatedText = Translate( translatedText, lang );
            }

            return translatedText;
        }

        public static string Translate( string text, string targetLanguage )
        {
            string translatedText = text;

            try
            {
                switch (translationEngine)
                {
                    case "BingTranslate":
                        var translator = new GoogleTranslator();
                        translatedText = translator.TranslateAsync(text, targetLanguage).Result.Translation;
                        break;
                    case "GoogleTranslate":
                        translator = new GoogleTranslator();
                        translatedText = translator.TranslateAsync(text, targetLanguage).Result.Translation;
                        break;
                    case "GoogleTranslate2":
                        translator = new GoogleTranslator();
                        translatedText = translator.TranslateAsync(text, targetLanguage).Result.Translation;
                        break;
                    case "MicrosoftAzureTranslator":
                        translator = new GoogleTranslator();
                        translatedText = translator.TranslateAsync(text, targetLanguage).Result.Translation;
                        break;
                    case "YandexTranslate":
                        translator = new GoogleTranslator();
                        translatedText = translator.TranslateAsync(text, targetLanguage).Result.Translation;
                        break;
                    default:
                        break;
                }
            }
            catch { return text; }

            return translatedText;
        }
    }
}
