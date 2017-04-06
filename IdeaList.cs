using System;
using System.Collections.Generic;

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
    }
}