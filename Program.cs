using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dagboksappen
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            Dictionary<DateOnly, string> myDiary = new Dictionary<DateOnly, string>();

            DateOnly datum = Validering.GetDateOnly();
            myDiary[datum] = Validering.GetString();
             
            
            foreach(var entry in myDiary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }


        
        }
    
    }
                                            
}
