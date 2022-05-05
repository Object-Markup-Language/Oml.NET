using System.Text;

namespace Oml.NET.Utils
{
    /// <summary>
    /// Miscellaneous methods for working with strings.
    /// </summary>
    public static class StringUtils
    {
        /// <summary>
        /// Repeats a string <paramref name="count"/> times, with <paramref name="separator"/> between each repetition.
        /// </summary>
        /// <param name="text">The string to repeat.</param>
        /// <param name="count">The amount of times <paramref name="text"/> should be repeated.</param>
        /// <param name="separator">A string to insert between each repetition</param>
        /// <returns><paramref name="text"/> <paramref name="count"/> times, with <paramref name="separator"/> between each repetition.</returns>
        public static string Multiply(this string text, int count, string separator = "")
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                builder.Append(text);

                // Don't append the separator to the last repetition.
                if (i != count)
                    builder.Append(separator);
            }

            return builder.ToString();
        }
    }
}
