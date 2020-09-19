using System;

using DataRug.Common.Units;

namespace DataRug.API.Common.Units.Converters
{

    public interface IUnitConverter<TValue, TUnit>
        where TValue : struct, IEquatable<TValue>
        where TUnit : struct
    {
        UnitValue<TValue, TUnit> Convert(UnitValue<TValue, TUnit> input, TUnit unit);
    }

}