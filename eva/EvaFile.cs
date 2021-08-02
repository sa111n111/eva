/* author: Sutinder S. Saini */

using System;
using System.IO;
using System.Text;

namespace eva
{
    class EvaFile
    {
        public static void SaveFile(string text)
        {
            Console.WriteLine("Enter the name of the file you would like to save the file as: ");
            string file = Console.ReadLine();
            Console.WriteLine("Enter the name of the file you would like to save the file as: ");
            string location = Console.ReadLine();
            string formed = location + @"/" + file;

            //finally, save
            try
            {
                System.IO.File.WriteAllTextAsync(formed, text);
            }
            catch (Exception e)
            {
                Console.WriteLine($"\n\n!! EXCEPTION HIT: {e}");
                Console.ReadKey();
        }

        }

        public void ReadAndApplyConfig()
        {
            //todo
        }
    }
}
