using System;

using DataRug.API.Common.Units.Converters;
using DataRug.Common.Units;

namespace DataRug.Common.Extensions
{

    public static class UnitExtensions
    {
        /// <summary>
        /// Represents a binary operation delegate that takes a left- and right-hand operator.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <returns>The resulting value of the binary operation, if successful; otherwise, <c>default</c>.</returns>
        public delegate UnitValue <TValue, TUnit> BinaryDelegate <TValue, TUnit>
        (
            UnitValue <TValue, TUnit> lhs,
            UnitValue <TValue, TUnit> rhs)

            where TUnit : struct
            where TValue : struct, IEquatable <TValue>;

        /// <summary>
        /// Represents a unary operation delegate that takes a left-hand operator.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <returns>The resulting value of the unary operation, if successful; otherwise, <c>default</c>.</returns>
        public delegate UnitValue <TValue, TUnit> UnaryDelegate <TValue, TUnit>
        (
            UnitValue <TValue, TUnit> lhs)

            where TUnit : struct
            where TValue : struct, IEquatable <TValue>;

        /// <summary>
        /// Returns a <see cref="IUnitConverter{TValue,TUnit}"/> matching the specified <see cref="TUnit"/>.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <returns>The corresponding unit converter, if found; otherwise, <c>default</c>.</returns>
        internal static IUnitConverter <TValue, TUnit> GetConverter <TValue, TUnit>()
            where TUnit : struct
            where TValue : struct, IEquatable <TValue> 
        =>
            typeof (TUnit) == typeof (MassUnit)
                ? (IUnitConverter <TValue, TUnit>) Mass.Instance
            : typeof (TUnit) == typeof (TimeUnit)
                ? (IUnitConverter <TValue, TUnit>) Time.Instance
                : default;

        /// <summary>
        /// Performs a unary operator on the specified value and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="func">The right-hand operator.</param>
        /// <returns>The resulting value of the unary operation, if successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Unary<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnaryDelegate<TValue, TUnit> func
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue> =>
            Unit.New(
                func(
                        lhs
                    )
                   .Value,
                lhs.Unit
            )
            ?? default;

        /// <summary>
        /// Performs a binary operation on the specified values and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <param name="func">The binary function.</param>
        /// <returns>The resulting value of the binary operation, if successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Binary<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs,
            BinaryDelegate<TValue, TUnit> func
        )
            where TValue : struct, IEquatable<TValue>
            where TUnit : struct =>
            Unit.New(
                func(
                        lhs,
                        rhs
                    )
                   .Value,
                lhs.Unit
            )
            ?? default;

        /// <summary>
        /// Converts a <see cref="UnitValue{TValue,TUnit}"/> to the specified unit.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="unitValue">The unit value to convert.</param>
        /// <param name="newUnit">The unit to convert the value to.</param>
        /// <returns>The converted value, if the operation was successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Convert<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> unitValue,
            TUnit newUnit
        )
            where TValue : struct, IEquatable<TValue>
            where TUnit : struct =>
            GetConverter<TValue, TUnit>()
               .Convert(unitValue, newUnit);

        /// <summary>
        /// Adds the specified <see cref="UnitValue{TValue,TUnit}"/> objects and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <returns>The resulting value, if the operation was successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Add<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue> =>
            lhs.Binary(
                rhs,
                (left, right) => !(left.Value is float leftValue)
                    ? default
                    : !(Convert(rhs, lhs.Unit).Value is float rightValue)
                        ? default
                        : Unit.New(
                            value: leftValue + rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default
            );

        /// <summary>
        /// Subtracts the specified <see cref="UnitValue{TValue,TUnit}"/> objects and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <returns>The resulting value, if the operation was successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Subtract<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue> =>
            lhs.Binary(
                rhs,
                (left, right) => !(left.Value is float leftValue)
                    ? default
                    : !(Convert(rhs, lhs.Unit).Value is float rightValue)
                        ? default
                        : Unit.New(
                            value: leftValue - rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default
            );

        /// <summary>
        /// Multiplies the specified <see cref="UnitValue{TValue,TUnit}"/> objects and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <returns>The resulting value, if the operation was successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Multiply<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue> => lhs.Binary(
                rhs,
                (left, right) => !(left.Value is float leftValue)
                    ? default
                    : !(Convert(rhs, lhs.Unit).Value is float rightValue)
                        ? default
                        : Unit.New(
                            value: leftValue * rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default
        );

        /// <summary>
        /// Divides the specified <see cref="UnitValue{TValue,TUnit}"/> objects and returns the result.
        /// </summary>
        /// <typeparam name="TValue">The value type.</typeparam>
        /// <typeparam name="TUnit">The unit type.</typeparam>
        /// <param name="lhs">The left-hand operator.</param>
        /// <param name="rhs">The right-hand operator.</param>
        /// <returns>The resulting value, if the operation was successful; otherwise, <c>default</c>.</returns>
        public static UnitValue<TValue, TUnit> Divide<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue> => lhs.Binary(
                rhs,
                (left, right) => !(left.Value is float leftValue)
                    ? default
                    : !(Convert(rhs, lhs.Unit).Value is float rightValue)
                        ? default
                        : Unit.New(
                            value: leftValue / rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default
            );

    }

}