using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace DataRug
{
    /// <summary>
    /// Defines functionality for a key-value map storing objects by their unique identifier.
    /// </summary>
    public interface IUniqueMap
    {
        /// <summary>
        /// Removes an element with the specified identifier from the <see cref="IUniqueMap"/>.
        /// </summary>
        /// <param name="id">The identifier of the element to remove.</param>
        /// <returns><c>true</c> if the element was removed; otherwise, <c>false</c>.</returns>
        bool Remove(ulong id);

        /// <summary>
        /// Clears the <see cref="IUniqueMap"/> of all elements.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// Defines functionality for a generic key-value map storing objects by their unique identifier.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    public interface IUniqueMap<T> : IUniqueMap, IReadOnlyUniqueMap<T>
        where T : class, IUnique
    {
        /// <summary>
        /// Raised when an element has been added to the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        event EventHandler<ElementAddedEventArgs<T>> Added;

        /// <summary>
        /// Raised when an element has been removed from the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        event EventHandler<ElementRemovedEventArgs<T>> Removed;


        /// <summary>
        /// Gets the total number of items contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        int Count { get; }


        /// <summary>
        /// Gets a collection of all entries contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        IEnumerable<T> Entries { get; }


        /// <summary>
        /// Adds the specified element to the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to add.</param>
        void Add([NotNull] T item);

        /// <summary>
        /// Removes the specified element from the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns></returns>
        bool Remove([NotNull] T item);


        /// <summary>
        /// Returns a value indicating whether the specified element is contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to find.</param>
        /// <returns><c>true</c> if the element was found; otherwise, <c>false</c>.</returns>
        bool Contains([NotNull] T item);

        /// <summary>
        /// Returns a value indicating whether a specified collection of elements is contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="items">The elements to find.</param>
        /// <returns><c>true</c> if the elements were found; otherwise, <c>false</c>.</returns>
        bool ContainsAll([NotNull] IEnumerable<T> items);


        /// <summary>
        /// Returns an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to get.</param>
        /// <returns>The element with the specified identifier, if found; otherwise, <c>null</c>.</returns>
        T Get(ulong id);


        /// <summary>
        /// Fetches an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to fetch.</param>
        /// <param name="result">The resulting element.</param>
        /// <returns><c>true</c> if an element was found; otherwise, <c>false</c>.</returns>
        bool TryGetItem(ulong id, out T result);
    }

}