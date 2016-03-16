namespace DuplicateWordsFinder.App
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var sentence = Console.ReadLine();
            var finder = new DuplicateFinder(sentence);
            finder.FindDuplicates();
            finder.PrintDuplicates();
        }
    }
}
