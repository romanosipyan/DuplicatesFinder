namespace DuplicateWordsFinder.App
{
    using System;
    using System.Collections.Generic;

    public sealed class DuplicateFinder
    {
        private Dictionary<string, uint> words;
        private readonly string[] separators = new string[] { ",", ".", "!", " ", "?" };

        public DuplicateFinder(string sentence)
        {
            this.Sentence = sentence;
            this.words = new Dictionary<string, uint>();
        }

        public string Sentence { get; set; }

        public Dictionary<string, uint> FindDuplicates()
        {
            if (!string.IsNullOrEmpty(this.Sentence))
            {
                foreach (string word in this.Sentence.Split(this.separators, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (this.words.ContainsKey(word))
                    {
                        this.words[word]++;
                    }
                    else
                    {
                        this.words.Add(word, 1);
                    }
                }
            }

            return this.words;
        }

        public void PrintDuplicates()
        {
            foreach (var word in this.words)
            {
                Console.WriteLine(string.Format("{0} - {1}", word.Key, word.Value));
            }
        }
    }
}
