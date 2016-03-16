namespace DuplicateWordsFinder.App
{
    using System;
    using System.Collections.Generic;

    // Overall algorithm time complexity is O(N)
    // Overall space complexity is ~ 2 * N + M * K, where M <= N/2, K <= N
    public sealed class DuplicateFinder
    {
        private Dictionary<string, uint> words;
        private readonly char[] separators = { ',', '.', '!', ' ', '?' };

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
                /* Time complexity is O(N)              
                where N = this.Sentence.Length */
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
            /* Time complexity is O(M)
                where M <= N/2
                where N = this.Sentence.Length */
            foreach (var word in this.words)
            {
                Console.WriteLine(string.Format("{0} - {1}", word.Key, word.Value));
            }
        }
    }
}
