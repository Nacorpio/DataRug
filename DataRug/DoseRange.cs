using System;

using JetBrains.Annotations;

namespace DataRug
{

    /// <summary>
    /// Represents information about a dose range.
    /// </summary>
    public readonly struct DoseRange : IUnitRange<float, MassUnit>, IEquatable<DoseRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoseRange"/> structure.
        /// </summary>
        /// <param name="min">The minimum dose.</param>
        /// <param name="max">The maximum dose.</param>
        /// <param name="unit">The mass unit to use.</param>
        public DoseRange(float? min, float? max, [NotNull] MassUnit unit = MassUnit.Undefined)
        {
            Minimum = min;
            Maximum = max;
            Unit = unit;
        }

        /// <summary>
        /// Gets the mass unit of the <see cref="DoseRange"/>.
        /// </summary>
        public MassUnit Unit { get; }


        /// <summary>
        /// Gets the minimum value in the range.
        /// </summary>
        public float? Minimum { get; }

        /// <summary>
        /// Gets the maximum value in the range.
        /// </summary>
        public float? Maximum { get; }


        /// <summary>
        /// Returns a value indicating whether the <see cref="DoseRange"/> has a lower bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a lower bound; otherwise, <c>false</c>.</returns>
        public bool HasLowerBound() => Minimum != null;

        /// <summary>
        /// Returns a value indicating whether the <see cref="DoseRange"/> has a upper bound.
        /// </summary>
        /// <returns><c>true</c> if the range has a upper bound; otherwise, <c>false</c>.</returns>
        public bool HasUpperBound() => Maximum != null;


        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(DoseRange other)
        {
            return Unit == other.Unit && Nullable.Equals(Minimum, other.Minimum) && Nullable.Equals(Maximum, other.Maximum);
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance. </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />. </returns>
        public override bool Equals(object obj)
        {
            return obj is DoseRange other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (int)Unit;
                hashCode = (hashCode * 397) ^ Minimum.GetHashCode();
                hashCode = (hashCode * 397) ^ Maximum.GetHashCode();

                return hashCode;
            }
        }
    }

}