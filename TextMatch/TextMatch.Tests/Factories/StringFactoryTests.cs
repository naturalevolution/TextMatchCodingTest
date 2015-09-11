using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TextMatch.Factories;

namespace TextMatch.Tests.Factories
{
    [TestClass]
    public class StringFactoryTests : BaseFactoryTests
    {
        [TestInitialize]
        public void SetUp()
        {
            FactoryToTest = new StringFactory(); 
        }

        public StringFactory FactoryToTest { get; set; }

        [TestMethod]
        public void Match_Should_Retrieve_Positions()
        {
            AssertPositions("Polly", "p", 1);
            AssertPositions("Polly", "ll", 3);
            AssertPositions("11112", "12", 4);
            AssertPositions("aaaa", "aa", 1, 2, 3);
            AssertPositions("Polly put the kettle on, polly put the kettle on, polly put the ", "POLLY", 1, 26, 51);
            AssertPositions("Polly put the kettle on, polly put the kettle on, polly put the ", "polly", 1, 26, 51);
            AssertPositions("Polly put the kettle on", "X");
            AssertPositions("Polly put the kettle on", "Polx");
        }

        private void AssertPositions(string text, string subText, params int[] expectedPositions)
        { 
            var result = FactoryToTest.Match(text, subText);
             
            Assert.AreEqual(expectedPositions.Length, result.Count);
            for (int i = 0; i < expectedPositions.Length; i++)
            {
                Assert.AreEqual(expectedPositions[i], result.ElementAt(i));
            }
        } 
    }
}
