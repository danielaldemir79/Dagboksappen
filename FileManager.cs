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
                    return;
                }

                if (!File.Exists(jsonFile))
                {
                    using (File.Create(jsonFile)) { }
                }

                string jsonString = JsonSerializer.Serialize(DiaryTools.myDiary);
                File.WriteAllText(jsonFile, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid sparning till filen: {ex.Message}");

            }
        }
        

        
        public static void LoadFromFile()
        {

            try
            {

                if (!File.Exists(jsonFile))
                {
                    Console.WriteLine("Det fanns ingen fil att ladda ifrån");
                    return;
                }

                if (new FileInfo(jsonFile).Length == 0)
                {
                    Console.WriteLine("Filen är tom, inga anteckningar att ladda");
                    return;
                }
                Console.WriteLine("Data har laddats upp från sparad fil");
                string jsonString = File.ReadAllText(jsonFile);
                DiaryTools.myDiary = JsonSerializer.Deserialize<Dictionary<DateTime, String>>(jsonString);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel uppstod vid inläsning av filen: {ex.Message}");
            }
        
        }
    }
}
