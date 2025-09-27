using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Reflection.Metadata.Ecma335;

namespace Dagboksappen
{
    internal class FileManager
    {

        public static string jsonFile = "diary.json";


        public static void SaveToFile()
        {

            try
            {

                if (DiaryTools.myDiary.Count == 0)
                {
                    File.WriteAllText(jsonFile, string.Empty);
                    Console.Clear();
                    Design.Red("\n Inga anteckningar att spara\n\n");
                    return;
                }

                if (!File.Exists(jsonFile))
                {
                    using (File.Create(jsonFile)) { }
                }

                string jsonString = JsonSerializer.Serialize(DiaryTools.myDiary);
                File.WriteAllText(jsonFile, jsonString);
                Console.Clear();
                Design.Green("\n Data har sparats till fil\n\n");
            }
            catch (Exception ex)
            {
                Console.Clear();
                Design.Red($"\n Ett fel uppstod vid sparning till filen: {ex.Message}\n"); 

            }
        }
        

        
        public static void LoadFromFile()
        {

            try
            {

                if (!File.Exists(jsonFile))
                {
                    Console.Clear();
                    Design.Blue("\n Det fanns ingen fil att ladda ifrån\n");
                    return;
                }

                if (new FileInfo(jsonFile).Length == 0)
                {
                    Console.Clear();
                    Design.Blue("\n Filen är tom, inga anteckningar att ladda\n");
                    return;
                }
                Console.Clear();
                Design.Green("\n Data har laddats upp från sparad fil\n\n");
                string jsonString = File.ReadAllText(jsonFile);
                DiaryTools.myDiary = JsonSerializer.Deserialize<Dictionary<DateTime, String>>(jsonString);

            }
            catch (Exception ex)
            {
                Console.Clear();

                Design.Red($"\n Ett fel uppstod vid inläsning av filen: {ex.Message}\n");
                
            }
        
        }
    }
}
