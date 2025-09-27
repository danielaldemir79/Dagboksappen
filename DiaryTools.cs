using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    internal class DiaryTools
    {

        Dictionary<DateTime, string> myDiary = new Dictionary<DateTime, string>();
        DiaryEntry diaryEntry = new DiaryEntry();


        public void AddNote()
        {
            DateTime date = DiaryEntry.EnterDate();

            if (myDiary.ContainsKey(date))
            {
                Console.WriteLine("Det finns redan en anteckning för detta datum");
                return;
            }

            Console.WriteLine("Skriv din anteckning:");
            string text = DiaryEntry.EnterText();
            myDiary[date] = text;
            Console.WriteLine("Anteckningen har lagts till.");
        }

        
        public void RemoveNote()
        {

            DateTime date = DiaryEntry.EnterDate();
           
            if(!myDiary.ContainsKey(date))
            {
                Console.WriteLine("Det finns ingen anteckning för detta datum");
                return;
            }
           
            myDiary.Remove(date);
            Console.WriteLine("Anteckningen har tagits bort.");

        }

       
        public void ListNotes()
        {
            if (myDiary.Count == 0)
            {
                Console.WriteLine("Inga anteckningar att visa.");
                return;
            }
            
            foreach (var entry in myDiary)
            {
                Console.WriteLine($"{entry.Key:yyyy-MM-dd}: {entry.Value}");
            }
        }
    }
}
