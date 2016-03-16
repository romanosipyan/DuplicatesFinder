using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DuplicateWordsFinder.App;
using System.Linq;

namespace DuplicateWordsFinder.Tests
{
    [TestClass]
    public class FinderTest
    {
        [TestMethod]
        public void EmptyInputTest()
        {
            var finder = new DuplicateFinder(null);
            var words = finder.FindDuplicates();

            Assert.IsNotNull(words);
            Assert.IsFalse(words.Keys.Any());
        }

        [TestMethod]
        public void ChangeInputTest()
        {
            var finder = new DuplicateFinder(null);
            var words = finder.FindDuplicates();

            Assert.IsNotNull(words);
            Assert.IsFalse(words.Keys.Any());

            finder.Sentence = "New text should change the result";
            words = finder.FindDuplicates();

            Assert.IsTrue(words.Keys.Any());
        }

        [TestMethod]
        public void InputWithNoDuplicatesTest()
        {
            var finder = new DuplicateFinder("I do not repeat myself in this sentence");
            var words = finder.FindDuplicates();

            Assert.IsNotNull(words);
            Assert.IsTrue(words.Keys.Any());
            Assert.IsTrue(words.Values.All(v => v == 1));
        }

        [TestMethod]
        public void InputWithDuplicatesTest()
        {
            var finder = new DuplicateFinder("I am going to repeat some words in this sentence as I want to test how much I repeat myself");
            var words = finder.FindDuplicates();

            Assert.IsNotNull(words);
            Assert.IsTrue(words.Keys.Any());
            Assert.IsTrue(words.Values.Any(v => v > 1));
        }
    }
}
