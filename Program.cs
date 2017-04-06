using System;

namespace IdealistParser
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFileText("/Users/niederer/core/IdeaListParser/test/TestIdeas.txt");
            
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PrintFileText(string filePath)
        {
            ReadIdeaText rit = new ReadIdeaText(filePath);

            Console.WriteLine(rit.FileContents);
        }
    }
}
