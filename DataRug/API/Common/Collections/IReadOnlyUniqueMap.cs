using System.Collections.Generic;

namespace DataRug.API.Common.Collections
{

    /// <summary>
    /// Defines functionality for a read-only store for 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyUniqueMap<out T> : IEnumerable<T>
        where T : IUnique
    {
        /// <summary>
        /// Gets an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to get.</param>
        /// <returns>The element, if found; otherwise, <c>null</c>.</returns>
        T this[ulong id] { get; }

        /// <summary>
        /// Returns a value indicating whether the <see cref="IReadOnlyUniqueMap{T}"/> contains an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to find.</param>
        /// <returns><c>true</c> if the element was found; otherwise, <c>false</c>.</returns>
        bool Contains(ulong id);
    }

}