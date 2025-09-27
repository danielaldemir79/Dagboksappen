using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    internal class DiaryTools
    {

        Dictionary<DateOnly, string> myDiary = new Dictionary<DateOnly, string>();
        DiaryEntry diaryEntry = new DiaryEntry();


        public void AddNote()
        {
            DateOnly date = DiaryEntry.EnterDate();

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


    }
}
