using System;

namespace DataRug
{

    public interface IUnitConverter<TValue, TUnit>
        where TValue : struct, IEquatable<TValue>
        where TUnit : struct
    {
        UnitValue<TValue, TUnit> Convert(UnitValue<TValue, TUnit> input, TUnit unit);
    }

}