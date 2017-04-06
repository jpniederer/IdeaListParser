using System;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace IdealistParser
{
    public class ReadIdeaText
    {
        public string FilePath { get; set; }
        public string FileContents { get; set; }
        public List<IdeaList> IdeaLists { get; set; }

        public ReadIdeaText()
        {
            IdeaLists = new List<IdeaList>();
        }

        public ReadIdeaText(string filePath)
        {
            FilePath = filePath;
            IdeaLists = new List<IdeaList>();
            SetFileContents();
        }

        private void SetFileContents()
        {
            if (File.Exists(FilePath))
            {
                FileStream fs = new FileStream(FilePath, FileMode.Open);

                using (StreamReader reader = new StreamReader(fs))
                {
                    FileContents = reader.ReadToEnd();
                }
            }
        }

        public void UpdateFilePath(string filePath)
        {
            FilePath = filePath;
            SetFileContents();
        }
    }
}