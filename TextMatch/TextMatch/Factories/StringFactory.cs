using System.Collections.Generic;

namespace TextMatch.Factories
{
    public class StringFactory : IStringFactory
    {
        public List<int> Match(string text, string subText)
        {
            var element = new StringMatcher(text, subText);
            element.SearchAllPositions();
            return element.Positions;
        }
    }

    public interface IStringFactory
    {
        /// <summary>
        /// Retrieve positions of SubText in a Text
        /// </summary>
        /// <param name="text">Value</param>
        /// <param name="subText">Searching value</param>
        /// <returns></returns>
        List<int> Match(string text, string subText);
    }
}