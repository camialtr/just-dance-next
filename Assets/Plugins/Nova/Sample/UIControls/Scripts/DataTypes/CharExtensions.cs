using TMPro;

namespace NovaSamples.UIControls
{
    /// <summary>
    /// Some utility extensions used by <see cref="TextField"/> and friends.
    /// </summary>
    public static class CharExtensions
    {
        public const char EmptyWidthSpace = '\u200B';

        /// <summary>
        /// Is this a newline character?
        /// </summary>
        public static bool IsNewline(this char c)
        {
            return c == '\n';
        }

        /// <summary>
        /// Empty spaces are added after newlines to ensure proper cursor positioning,
        /// see <see cref="TextField.ToDisplayText(string)"/>
        /// </summary>
        public static bool IsEmptySpace(this char c)
        {
            return c == EmptyWidthSpace;
        }

        /// <summary>
        /// This this a newline character?
        /// </summary>
        public static bool IsNewline(this TMP_CharacterInfo c)
        {
            return c.character == '\n';
        }

        private const float Epsilon = .0001f;
        /// <summary>
        /// Does this character have width?
        /// </summary>
        public static bool HasWidth(this TMP_CharacterInfo charInfo)
        {
            return (charInfo.xAdvance - charInfo.origin) > Epsilon;
        }
    }
}
