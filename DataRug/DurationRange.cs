using System;

using JetBrains.Annotations;

using Newtonsoft.Json;

namespace DataRug
{

    /// <summary>
    /// Represents a duration range.
    /// </summary>
    public readonly struct DurationRange : IUnitRange<int, TimeUnit>, IEquatable<DurationRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DurationRange"/> structure.
        /// </summary>
        /// <param name="min">The lower bound of the range.</param>
        /// <param name="max">The upper bound of the range.</param>
        /// <param name="unit">The unit to use.</param>
        public DurationRange([CanBeNull] int? min, [CanBeNull] int? max, [NotNull] TimeUnit unit)
        {
            if (min >= max)
            {
                throw new ArgumentOutOfRangeException(nameof(min));
            }

            if (max <= min)
            {
                throw new ArgumentOutOfRangeException(nameof(max));
            }

            Unit = unit;
            Minimum = min;
            Maximum = max;
        }


        /// <summary>
        /// Gets the lower bound of the <see cref="DurationRange"/>.
        /// </summary>
        [JsonProperty("min", Required = Required.AllowNull)]
        public int? Minimum { get; }

        /// <summary>
        /// Gets the upper bound of the <see cref="DurationRange"/>.
        /// </summary>
        [JsonProperty("max", Required = Required.AllowNull)]
        public int? Maximum { get; }

        /// <summary>
        /// Gets the unit of the <see cref="DurationRange"/>.
        /// </summary>
        [JsonProperty("unit", Required = Required.Always)]
        public TimeUnit Unit { get; }


        /// <summary>
        /// Returns a value indicating whether the <see cref="DurationRange"/> has a lower bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a lower bound; otherwise, <c>false</c>.</returns>
        public bool HasLowerBound() => Minimum != null;

        /// <summary>
        /// Returns a value indicating whether the <see cref="DurationRange"/> has a upper bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a upper bound; otherwise, <c>false</c>.</returns>
        public bool HasUpperBound() => Maximum != null;


        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(DurationRange other)
        {
            return Minimum == other.Minimum && Maximum == other.Maximum && Unit == other.Unit;
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance. </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />. </returns>
        public override bool Equals(object obj)
        {
            return obj is DurationRange other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Minimum.GetHashCode();
                hashCode = (hashCode * 397) ^ Maximum.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)Unit;

                return hashCode;
            }
        }

        /// <summary>
        /// Creates and returns a new <see cref="DurationRange"/> object with the specified minimum- and maximum value.
        /// </summary>
        /// <param name="min">The minimum value (lower bound).</param>
        /// <param name="max">The maximum value (upper bound).</param>
        /// <param name="unit">The unit.</param>
        /// <returns>The newly created range.</returns>
        public static DurationRange Create(int min, int max, [NotNull] TimeUnit unit)
        {
            return new DurationRange(min, max, unit);
        }
    }

}