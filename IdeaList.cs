using System;
using System.Collections.Generic;
using System.Text;

namespace IdealistParser
{
    public class IdeaList
    {
        public DateTime ListDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Idea> Ideas { get; set; }
        public string Tag { get; set; }

        public IdeaList() 
        {
            Ideas = new List<Idea>();
        }

        public void AddIdea(Idea idea)
        {
            Ideas.Add(idea);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(ListDate.Date.ToString());
            sb.AppendLine(Title);
            sb.AppendLine(Description);
            
            foreach (var idea in Ideas)
            {
                sb.AppendLine(idea.ToString());
            }

            sb.AppendLine(Tag);

            return sb.ToString();
        }
    }
}