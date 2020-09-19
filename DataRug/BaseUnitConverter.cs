using System;
using JetBrains.Annotations;

namespace DataRug
{

    public abstract class BaseUnitConverter<TValue, TUnit> : IUnitConverter<TValue, TUnit>
        where TValue : struct, IEquatable<TValue> where TUnit : struct
    {
        public delegate UnitValue<TValue, TUnit>? UnitConversionDelegate(UnitValue<TValue, TUnit> input, [NotNull] TUnit unit);

        private readonly UnitConversionDelegate _conversionFunc;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        /// <param name="conversionFunc">The function used to convert a unit value.</param>
        protected BaseUnitConverter(UnitConversionDelegate conversionFunc)
        {
            _conversionFunc = conversionFunc;
        }

        /// <summary>
        /// Converts the specified <see cref="BaseUnitConverter{TValue,TUnit}"/>
        /// </summary>
        /// <param name="input">The input to convert.</param>
        /// <param name="unit">The unit to convert to.</param>
        /// <returns>The converted value, if the conversion was successful; otherwise, <c>default</c>.</returns>
        public UnitValue<TValue, TUnit> Convert(UnitValue<TValue, TUnit> input, [NotNull] TUnit unit)
        {
            return _conversionFunc?.Invoke(input, unit) is { } output ? output : default;
        }
    }

}