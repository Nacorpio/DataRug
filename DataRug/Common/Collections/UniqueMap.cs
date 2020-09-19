using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DataRug.API.Common;
using DataRug.API.Common.Collections;

namespace DataRug.Common.Collections
{

    public class UniqueMap<T> : IUniqueMap<T> where T : class, IUnique
    {
        private readonly Dictionary<ulong, T> _elements;

        /// <summary>
        /// Raised when an element has been added to the <see cref="UniqueMap{T}"/>.
        /// </summary>
        public event EventHandler<ElementAddedEventArgs<T>> Added;

        /// <summary>
        /// Raised when an element has been removed from the <see cref="UniqueMap{T}"/>.
        /// </summary>
        public event EventHandler<ElementRemovedEventArgs<T>> Removed;


        /// <summary>
        /// Initializes a new instance of the <see cref="UniqueMap{T}"/> class.
        /// </summary>
        public UniqueMap()
        {
            _elements = new Dictionary<ulong, T>();
        }


        /// <summary>
        /// Gets an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to get.</param>
        /// <returns>The element with the specified identifier, if found; otherwise, <c>null</c>.</returns>
        public T this[ulong id] => TryGetItem(id, out var result) ? result : null;


        /// <summary>
        /// Gets the total number of items contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        public int Count => _elements.Count;

        /// <summary>
        /// Gets a collection of all entries contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        public IEnumerable<T> Entries => _elements.Values;


        /// <summary>
        /// Adds the specified element to the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to add.</param>
        public void Add(T item)
        {
            if (Contains(item))
            {
                return;
            }

            if (!(item.Id is ulong itemId))
            {
                return;
            }

            _elements.Add(itemId, item);
            OnAdded(new ElementAddedEventArgs<T>(this, item));
        }


        /// <returns>The element with the specified identifier, if found; otherwise, <c>null</c>.</returns>
        /// <summary>
        /// Returns an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to get.</param>
        public T Get(ulong id)
        {
            return TryGetItem(id, out var result) ? result : null;
        }


        /// <summary>
        /// Removes the specified element from the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to remove.</param>
        /// <returns></returns>
        public bool Remove(T item)
        {
            if (!(item.Id is ulong itemId && Remove(itemId)))
            {
                return false;
            }

            OnRemoved(new ElementRemovedEventArgs<T>(this, item));
            return true;
        }

        /// <summary>
        /// Removes an element with the specified identifier from the <see cref="IUniqueMap"/>.
        /// </summary>
        /// <param name="id">The identifier of the element to remove.</param>
        /// <returns><c>true</c> if the element was removed; otherwise, <c>false</c>.</returns>
        public bool Remove(ulong id)
        {
            return _elements.Remove(id);
        }


        /// <summary>
        /// Returns a value indicating whether the specified element is contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="item">The element to find.</param>
        /// <returns><c>true</c> if the element was found; otherwise, <c>false</c>.</returns>
        public bool Contains(T item)
        {
            return item.Id is ulong itemId && _elements.ContainsKey(itemId);
        }

        /// <summary>
        /// Returns a value indicating whether an element with the specified identifier is contained in the <see cref="UniqueMap{T}"/>.
        /// </summary>
        /// <param name="id">The identifier of the element to find.</param>
        /// <returns><c>true</c> if the element was found; otherwise, <c>false</c>.</returns>
        public bool Contains(ulong id)
        {
            return _elements.ContainsKey(id);
        }

        /// <summary>
        /// Returns a value indicating whether a specified collection of elements is contained in the <see cref="IUniqueMap{T}"/>.
        /// </summary>
        /// <param name="items">The elements to find.</param>
        /// <returns><c>true</c> if the elements were found; otherwise, <c>false</c>.</returns>
        public bool ContainsAll(IEnumerable<T> items)
        {
            return items.All(Contains);
        }


        /// <summary>
        /// Clears the <see cref="IUniqueMap"/> of all elements.
        /// </summary>
        public void Clear()
        {
            foreach (var key in _elements.Keys)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// Fetches an element with the specified identifier.
        /// </summary>
        /// <param name="id">The identifier of the element to fetch.</param>
        /// <param name="result">The resulting element.</param>
        /// <returns><c>true</c> if an element was found; otherwise, <c>false</c>.</returns>
        public bool TryGetItem(ulong id, out T result)
        {
            return _elements.TryGetValue(id, out result);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _elements.Values.GetEnumerator();
        }

        /// <summary>Returns an enumerator that iterates through a collection.</summary>
        /// <returns>An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        protected virtual void OnAdded(ElementAddedEventArgs<T> e)
        {
            Added?.Invoke(this, e);
        }

        protected virtual void OnRemoved(ElementRemovedEventArgs<T> e)
        {
            Removed?.Invoke(this, e);
        }
    }

}