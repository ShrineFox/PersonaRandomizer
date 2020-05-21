using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AtlusRandomizer
{
    public static class BadTranslator
    {
        private static readonly string sTranslateUrlFormat = "https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}";
        private static readonly WebClient sClient = new WebClient();
        private static readonly StringBuilder sBuilder = new StringBuilder( 64 );
        private static readonly Dictionary<string, string> sTranslationCache = new Dictionary<string, string>( 1024 );

        public static void Translate( string[] array, out string[] translated )
        {
            translated = new string[array.Length];
            List<Tuple<string, string>> sTranslationLanguages = new List<Tuple<string, string>> {
            new Tuple<string, string>("", "") };
            using (var translateDialog = new TranslationDialog())
            {
                if (translateDialog.ShowDialog() != DialogResult.OK)
                    return;

                sTranslationLanguages = translateDialog.Result.sTranslationLanguages;
                translateDialog.Close();
            }
            
            for (int i = 0; i < array.Length; i++)
                translated[i] = Translate(array[i], sTranslationLanguages.ToArray());
        }

        public static string Translate( string text, Tuple<string, string>[] sTranslationLanguages)
        {
            if ( !sTranslationCache.TryGetValue(text, out var translatedText))
            {
                translatedText = text;

                foreach ( var lang in sTranslationLanguages )
                    translatedText = Translate( translatedText, lang.Item1, lang.Item2 );

                translatedText = WebUtility.HtmlDecode( translatedText );

                sTranslationCache[text] = translatedText;
                Console.WriteLine( $"{text} -> {translatedText}" );
            }

            return translatedText;
        }

        private static string Translate( string text, string sourceLanguage, string targetLanguage )
        {
            sClient.Headers.Add( "user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)" );
            sClient.Proxy = null;

            var url = string.Format( sTranslateUrlFormat, sourceLanguage, targetLanguage, WebUtility.UrlEncode(text) );
            var jsonString = Encoding.UTF8.GetString( sClient.DownloadData( url ) );
            var translationUnit = JsonConvert.DeserializeObject<JArray>( jsonString );

            foreach ( var item in ((JArray)translationUnit.First) )
            {
                if ( sBuilder.Length != 0 )
                    sBuilder.Append( " " );

                sBuilder.Append( ( string )( ( ( JValue )item.First ).Value ) );
            }

            var str = sBuilder.ToString();
            sBuilder.Clear();

            return str;
        }
    }
}
