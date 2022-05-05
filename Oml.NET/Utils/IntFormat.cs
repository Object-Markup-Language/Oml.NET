using System;

namespace Oml.NET.Utils
{
    /// <summary>
    /// Various methods that format <see cref="int"/>s in specific ways.
    /// </summary>
    public static class IntFormat
    {
        /// <summary>
        /// Converts a number into it's binary string representation.
        /// </summary>
        /// <param name="value">The number to convert to binary.</param>
        /// <returns><paramref name="value"/> converted to a binary string.</returns>
        public static string ToBinaryString(this int value) => Convert.ToString(value, 2);

        /// <summary>
        /// Converts a number into it's hexadecimal string representation.
        /// </summary>
        /// <param name="value">The number to convert to hexadecimal.</param>
        /// <returns><paramref name="value"/> converted to a hexadecimal string.</returns>
        public static string ToHexString(this int value) => Convert.ToString(value, 16);

        /// <summary>
        /// Converts a binary string to it's equivalent <see cref="int"/>.
        /// </summary>
        /// <param name="value">The binary <see cref="string"/> to convert into a number.</param>
        /// <returns>The binary <see cref="int"/> <paramref name="value"/> as a decimal <see cref="int"/>.</returns>
        public static int FromBinaryString(this string value) => Convert.ToInt32(value, 2);

        /// <summary>
        /// Converts a hexedecimal string to it's equivalent <see cref="int"/>.
        /// </summary>
        /// <param name="value">The hexadecimal <see cref="string"/> to convert into a number.</param>
        /// <returns>The hexadecimal <see cref="int"/> <paramref name="value"/> as a decimal <see cref="int"/>.</returns>
        public static int FromHexString(this string value) => Convert.ToInt32(value, 16);
    }
}
