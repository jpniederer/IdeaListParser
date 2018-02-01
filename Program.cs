using System;

namespace IdealistParser
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintFileText("C:/Users/joshu/github/IdeaListParser/test/TestIdeas.txt");
            //PrintFileText("/Users/niederer/github/IdeaListParser/test/TestIdeas.txt");

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void PrintFileText(string filePath)
        {
            ReadIdeaText rit = new ReadIdeaText(filePath);
            string[] lines = rit.FileContents.Split('\n');

            LineProcessor lp = new LineProcessor(lines);

            foreach (var ideaList in lp.IdeaLists)
            {
                Console.WriteLine(ideaList.ToString());
            }
        }
    }
}
