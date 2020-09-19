using System;

using Newtonsoft.Json;

namespace DataRug
{

    /// <summary>
    /// Defines functionality for an object with a range and unit.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <typeparam name="TUnit">The unit type.</typeparam>
    public interface IUnitRange<TValue, out TUnit> : IRange<TValue> where TValue : struct, IEquatable <TValue>
    {
        /// <summary>
        /// Gets the unit of the range.
        /// </summary>
        [JsonProperty("unit", Required = Required.Always)]
        TUnit Unit { get; }
    }

}