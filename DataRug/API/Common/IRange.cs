using System;

using Newtonsoft.Json;

namespace DataRug.API.Common
{
    /// <summary>
    /// Defines functionality for an object that is a range of some sort.
    /// </summary>
    public interface IRange<TValue> where TValue : struct, IEquatable<TValue>
    {
        /// <summary>
        /// Gets the lower bound of the <see cref="IRange{TValue}"/>.
        /// </summary>
        [JsonProperty("min", Required = Required.AllowNull)]
        TValue? Minimum { get; }

        /// <summary>
        /// Gets the upper bound of the <see cref="IRange{TValue}"/>.
        /// </summary>
        [JsonProperty("max", Required = Required.AllowNull)]
        TValue? Maximum { get; }


        /// <summary>
        /// Returns a value indicating whether the <see cref="IRange{TValue}"/> has a lower bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a lower bound; otherwise, <c>false</c>.</returns>
        bool HasLowerBound();

        /// <summary>
        /// Returns a value indicating whether the <see cref="IRange{TValue}"/> has a upper bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a upper bound; otherwise, <c>false</c>.</returns>
        bool HasUpperBound();
    }

}