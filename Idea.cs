using System;

namespace IdealistParser
{
    public class Idea
    {
       public int Rank { get; set; }
       public string Title { get; set; }
       public string Description { get; set; }

       public override string ToString()
        {
            return string.Format("{0}. {1} - {2}", Rank, Title, Description);
        }
    }
}