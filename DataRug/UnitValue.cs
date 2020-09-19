using System;
using System.Collections.Generic;

using JetBrains.Annotations;

namespace DataRug
{

    /// <summary>
    /// Represents a mutable object that pairs a value and a unit.
    /// </summary>
    /// <typeparam name="TValue">The value type.</typeparam>
    /// <typeparam name="TUnit">The unit type.</typeparam>
    public readonly struct UnitValue<TValue, TUnit> : IEquatable<UnitValue<TValue, TUnit>>
        where TValue : struct, IEquatable<TValue> where TUnit : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitValue{TValue,TUnit}"/> structure.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="unit">The unit.</param>
        /// <remarks>
        /// Note: This constructor should only be used internally.
        /// </remarks>
        internal UnitValue([CanBeNull] TValue? value, [NotNull] TUnit unit)
        {
            Value = value;
            Unit = unit;
        }


        public static bool operator ==(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return !(lhs == rhs);
        }


        public static UnitValue<TValue, TUnit> operator +(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return lhs.Add(rhs);
        }

        public static UnitValue<TValue, TUnit> operator -(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return lhs.Subtract(rhs);
        }

        public static UnitValue<TValue, TUnit> operator *(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return lhs.Multiply(rhs);
        }

        public static UnitValue<TValue, TUnit> operator /(UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
        {
            return lhs.Divide(rhs);
        }


        /// <summary>
        /// Gets the value of the <see cref="UnitValue{TValue,TUnit}"/>.
        /// </summary>
        public TValue? Value { get; }

        /// <summary>
        /// Gets the unit of the <see cref="UnitValue{TValue,TUnit}"/>.
        /// </summary>
        public TUnit Unit { get; }

        /// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true" /> if the current object is equal to the <paramref name="other" /> parameter; otherwise, <see langword="false" />.</returns>
        public bool Equals(UnitValue<TValue, TUnit> other)
        {
            return Value.Equals(other.Value) && EqualityComparer<TUnit>.Default.Equals(Unit, other.Unit);
        }

        /// <summary>Indicates whether this instance and a specified object are equal.</summary>
        /// <param name="obj">The object to compare with the current instance. </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> and this instance are the same type and represent the same value; otherwise, <see langword="false" />. </returns>
        public override bool Equals(object obj)
        {
            return obj is UnitValue<TValue, TUnit> other && Equals(other);
        }

        /// <summary>Returns the hash code for this instance.</summary>
        /// <returns>A 32-bit signed integer that is the hash code for this instance.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (Value.GetHashCode() * 397) ^ EqualityComparer<TUnit>.Default.GetHashCode(Unit);
            }
        }
    }

}