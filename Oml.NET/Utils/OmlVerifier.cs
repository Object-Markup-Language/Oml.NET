using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Oml.NET.Exceptions;

namespace Oml.NET.Utils
{
    /// <summary>
    /// Regular expressions and helper methods to verify OML.
    /// </summary>
    public static class OmlVerifier
    {
        /// <summary>
        /// Regex matching any reserved characters.
        /// </summary>
        public static readonly Regex ReservedCharacters = new Regex(@"[=,\[\]\{\}\<\>\n\r]");

        /// <summary>
        /// Regex matching any additional forbidden characters for comment sequences (i.e. perioids, tabs, and spaces).
        /// </summary>
        public static readonly Regex CommentPrefixAdditionalForbiddenCharacters = new Regex(@"\.\t ");

        /// <summary>
        /// Regex matching any additional forbidden characters for keys (i.e. tabs and spaces).
        /// </summary>
        public static readonly Regex KeyAdditionalForbiddenCharacters = new Regex(@"\t ");

        /// <summary>
        /// Regex matching an entire string except any periods at the beginning or end.
        /// </summary>
        public static readonly Regex KeyNoPeriodAtStartOrEnd = new Regex(@"(?!\.).+(?<!\.)");

        /// <summary>
        /// Regex verifying that a section is properly formatted (square brackets around a key)
        /// </summary>
        public static readonly Regex SectionVerifyStructure = new Regex(@"\[.*\]");

        /// <summary>
        /// Regex to remove brackets from a section.
        /// </summary>
        public static readonly Regex SectionRemoveBrackets = new Regex(@"\[\]");

        public static void VerifyKey(string key)
        {
            MatchCollection matches = ReservedCharacters.Matches(key);
            if (matches.Any())
                throw new MalformedOmlException($"Key {key} contains reserved characters: {MatchesToString(matches)}");

            matches = KeyAdditionalForbiddenCharacters.Matches(key);
            if (matches.Any())
                throw new MalformedOmlException($"Key {key} contains forbidden characters (either tab or space): {MatchesToString(matches)}");

            matches = KeyNoPeriodAtStartOrEnd.Matches(key); // There should only ever be one match
            if (matches.First().Value.Length < key.Length)
                throw new MalformedOmlException($"Key {key} begins or ends with a period");
        }

        public static void VerifySectionStructure(string line)
        {
            if (!SectionVerifyStructure.IsMatch(line))
                throw new MalformedOmlException($"Malformed section: {line}");
        }

        public static void VerifySectionText(string sectionText)
        {
            sectionText = SectionRemoveBrackets.Replace(sectionText, "");

            MatchCollection matches = ReservedCharacters.Matches(sectionText);

            if (matches.Any())
                throw new MalformedOmlException($"Section {sectionText} contains reserved characters: {MatchesToString(matches)}");
        }

        public static string RemoveSectionBrackets(string sectionText) => SectionRemoveBrackets.Replace(sectionText, "");

        private static string MatchesToString(MatchCollection matches)
        {
            StringBuilder builder = new StringBuilder();

            foreach (Match match in matches)
                builder.Append(match.Value);

            return builder.ToString();
        }
    }
}
