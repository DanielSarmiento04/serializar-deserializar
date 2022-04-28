using Newtonsoft.Json;
using serealizar.Entidad;
using System.Collections.Generic;


namespace serealizar{
    class Program
    {
        private static string _path = @"C:\Users\Daniel\desktop\serealizar\translations.json";
        static void Main(string[] args)
        {
            // List<Translations> traducciones = GetTranslations();   
            // SerializeJsonFile(traducciones);
            string traducciones = GetTraduccionesFromFile();
            DeserializeJsonFile(traducciones);
        }
        public static string GetTraduccionesFromFile()
        {
            // string json = File.ReadAllText(_path);
            // return json;
            string traduccionesFromFile;
            using (StreamReader file = new StreamReader(_path))
            {
                traduccionesFromFile = file.ReadToEnd();
            }
            return traduccionesFromFile;
        }
        public static void DeserializeJsonFile(string TraduccionesJson)
        {
            var traducciones = JsonConvert.DeserializeObject<List<Translations>>(TraduccionesJson);
            Console.WriteLine(traducciones[0]?.translations[1].text);
        }
        #region "PostJson"
        public static List<Translations> GetTranslations(){
            List<Translations> translations = new List<Translations>();
            translations.Add(new Translations{
                // testReference = "translations",
                translations = new List<Translation>{
                    new Translation{
                        text = "Hello world",
                        to = "es"
                    }
                    , new Translation{
                        text = "Hola mundo",
                        to = "en"
                    }
                }
            });
            return translations;
        }
        public static void SerializeJsonFile(List<Translations> translations){
            string json = JsonConvert.SerializeObject(translations, Formatting.Indented);
            File.WriteAllText(_path, json);
        }
        #endregion
        
    }
}


