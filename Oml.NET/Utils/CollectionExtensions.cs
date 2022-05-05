using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Oml.NET.Utils
{
    /// <summary>
    /// Useful extension methods for working with <see cref="IEnumerable"/>s.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Gets the first occurance of <typeparamref name="T"/> from the strongly-typed collection <paramref name="collection"/> that satisfies <paramref name="predicate"/>.
        /// </summary>
        /// <typeparam name="T">The type of the elements in the collection.</typeparam>
        /// <param name="collection">The collection to get this element from.</param>
        /// <param name="predicate">A condition that an element must satisfy to be returned.</param>
        /// <param name="value">The found element, or <typeparamref name="T"/>'s default value if no matching element was found.</param>
        /// <returns>Whether or not a value was found.</returns>
        public static bool TryGet<T>(this IEnumerable<T> collection, Func<T, bool> predicate, out T value)
        {
            foreach (T element in collection)
            {
                if (predicate(element))
                {
                    value = element;
                    return true;
                }
            }

            value = default;
            return false;
        }

        /// <summary>
        /// Gets the index of the first element satisfying <paramref name="predicate"/> in the strongly typed collection <paramref name="collection"/>.
        /// </summary>
        /// <typeparam name="T">THe type of elements in the collection.</typeparam>
        /// <param name="collection">The collection to get this index from</param>
        /// <param name="predicate">A condition that an element must satisfy to return it's index.</param>
        /// <param name="value">The index of the first matching element, or -1 if no matching element was found.</param>
        /// <returns>Whether or not an index was found.</returns>
        public static bool TryGetIndex<T>(this IEnumerable<T> collection, Func<T, bool> predicate, out int value)
        {
            int count = collection.Count();
            IEnumerator enumerator = collection.GetEnumerator();

            for (int i = 0; i < count; i++)
            {
                T element = (T)enumerator.Current;
                enumerator.MoveNext();
                
                if (predicate(element))
                {
                    value = i;
                    return true;
                }
            }

            value = -1;
            return false;
        }
    }
}
