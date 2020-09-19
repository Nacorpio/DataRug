using System;

using JetBrains.Annotations;

namespace DataRug
{

    public static class Unit
    {
        /// <summary>
        /// Creates a unit value with the specified value and unit.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="value">The value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>The created unit value, if successful; otherwise, <c>null</c>.</returns>
        public static UnitValue<TValue, TUnit>? New<TValue, TUnit>
        (
            [CanBeNull] TValue? value,
            [NotNull] TUnit unit)
            where TValue : struct, IEquatable<TValue>
            where TUnit : struct
        {
            return new UnitValue<TValue, TUnit>(
                value,
                unit
            );
        }

        /// <summary>
        /// Creates a time unit value with the specified value and time unit.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="unit">The time unit.</param>
        /// <returns>The created unit value, if successful; otherwise, <c>null</c>.</returns>
        public static UnitValue<float, TimeUnit>? Time
        (
            [CanBeNull] float? value,
            [NotNull] TimeUnit unit) =>
            New(
                value,
                unit
            );

        /// <summary>
        /// Creates a mass unit value with the specified value and mass unit.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="unit">The mass unit.</param>
        /// <returns>The created unit value, if successful; otherwise, <c>null</c>.</returns>
        public static UnitValue<float, MassUnit>? Mass
        (
            [CanBeNull] float? value,
            [NotNull] MassUnit unit) =>
            New(
                value,
                unit
            );
    }

}