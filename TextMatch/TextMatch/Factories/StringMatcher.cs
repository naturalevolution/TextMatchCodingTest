using System;
using System.Collections.Generic;

namespace TextMatch.Factories
{
    /// <summary>
    /// StringMatcher permit to retrieve positions of SubText in a Text
    /// </summary>
    public class StringMatcher
    {
        public StringMatcher(string text, string subText)
        {
            Text = text;
            SubText = subText;
            Positions = new List<int>();
        }

        private string Text { get; set; }
        private string SubText { get; set; }
        public List<int> Positions { get; set; }

        /// <summary>
        /// Retrieve all the positions
        /// </summary>
        public void SearchAllPositions()
        {
            for (var i = 0; i < Text.Length; i++)
            {
                SearchPositionInText(i, 0, i);
            }
        }
        /// <summary>
        /// Retrieve and add a character position
        /// </summary>
        /// <param name="textPosition">Current position of the text</param>
        /// <param name="subTextPosition">Current position of the sub text</param>
        /// <param name="firstPosition">First position found</param>
        private void SearchPositionInText(int textPosition, int subTextPosition, int firstPosition)
        {
            if (textPosition < Text.Length && subTextPosition < SubText.Length &&
                (Char.ToLower(Text[textPosition]) == Char.ToLower(SubText[subTextPosition])))
            {
                if (SubText.Length > subTextPosition + 1)
                {
                    SearchPositionInText(textPosition + 1, subTextPosition + 1, firstPosition);
                }
                else
                {
                    Positions.Add(firstPosition + 1);
                }
            }
        }
    }
}