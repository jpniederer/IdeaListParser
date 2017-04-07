using System;
using System.Collections.Generic;

namespace IdealistParser
{
    public class LineProcessor
    {
        public string[] Lines { get; set; }
        public List<IdeaList> IdeaLists { get; private set; }

        public LineProcessor() 
        { 
            IdeaLists = new List<IdeaList>();
        }

        public LineProcessor(string[] lines)
        {
            Lines = lines;
            IdeaLists = new List<IdeaList>();
            ProcessLines();
        }

        private void  ProcessLines()
        {
             for (int i = 0; i < Lines.Length - 2; i++)
            {
                string cleaned = Lines[i].TrimStart(' ');
                DateTime date;

                if (DateTime.TryParse(cleaned, out date))
                {
                    IdeaList il = new IdeaList();
                    il.ListDate = date;
                    string line = Lines[i].TrimStart(' ');
                    DateTime d;
                    int innerIndex = i + 2;

                    il.Title = Lines[i + 1];
                    il.Description = Lines[i + 2];
                    line = Lines[i + 1].TrimStart(' ');

                    while (!DateTime.TryParse(line, out d) && innerIndex < Lines.Length - 1 && line != "")
                    {
                        char firstCharacter = line[0];

                        if (firstCharacter == '[')
                        {
                            il.Tag = line;
                        }

                        int num;
                        if (int.TryParse(firstCharacter.ToString(), out num))
                        {
                            il.AddIdea(ParseIdea(line));
                        }

                        innerIndex++;
                        line = Lines[innerIndex].TrimStart();                       
                    }

                    IdeaLists.Add(il);
                }
            }
        }

        private Idea ParseIdea(string line)
        {
            Idea idea = new Idea();

            idea.Rank = GetRank(line);
            idea.Title = GetTitle(line);
            idea.Description = GetDescription(line);

            return idea;
        }

        private int GetRank(string line)
        {
            int indexOfPeriod = line.IndexOf('.');
            string numString = line.Substring(0, indexOfPeriod);

            return int.Parse(numString);
        }

        private string GetTitle(string line)
        {
            int indexOfPeriod = line.IndexOf('.');
            int indexOfDash = line.IndexOf('-');

            if (indexOfDash == -1)
            {
                return line.Substring(indexOfPeriod + 2, line.Length - indexOfPeriod - 3);
            }
            
            return line.Substring(indexOfPeriod + 2, indexOfDash - indexOfPeriod - 2);
        }

        private string GetDescription(string line)
        {
            int indexOfDash = line.IndexOf('-');

            if (indexOfDash == -1)
            {
                return "";
            }
            
            return line.Substring(indexOfDash + 1, line.Length - indexOfDash - 1);
        }
    }
}