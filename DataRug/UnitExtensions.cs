using System;

namespace DataRug
{

    public static class UnitExtensions
    {
        public delegate UnitValue<TValue, TUnit> BinaryDelegate<TValue, TUnit>
            (UnitValue<TValue, TUnit> lhs, UnitValue<TValue, TUnit> rhs)
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>;

        public delegate UnitValue<TValue, TUnit> UnaryDelegate<TValue, TUnit>(UnitValue<TValue, TUnit> lhs)
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>;

        public static UnitValue<TValue, TUnit> Unary<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnaryDelegate<TValue, TUnit> func
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            return Unit.New(func(lhs).Value, lhs.Unit) ?? default;
        }

        public static UnitValue<TValue, TUnit> Binary<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs,
            BinaryDelegate<TValue, TUnit> func
        )
            where TValue : struct, IEquatable<TValue>
            where TUnit : struct
        {
            return Unit.New(func(lhs, rhs).Value, lhs.Unit) ?? default;
        }

        public static IUnitConverter<TValue, TUnit> GetUnitConverter<TValue, TUnit>()
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            if (typeof(TUnit) == typeof(MassUnit))
            {
                return (IUnitConverter<TValue, TUnit>)Mass.Instance;
            }

            if (typeof(TUnit) == typeof(TimeUnit))
            {
                return (IUnitConverter<TValue, TUnit>)Time.Instance;
            }

            return default;
        }

        public static UnitValue<TValue, TUnit> Convert<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            TUnit newUnit
        )
            where TValue : struct, IEquatable<TValue>
            where TUnit : struct =>
            GetUnitConverter<TValue, TUnit>()
               .Convert(lhs, newUnit);

        public static UnitValue<TValue, TUnit> Add<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            return lhs.Binary(
                rhs,
                (left, right) =>
                {
                    var rValue = Convert(rhs, lhs.Unit);

                    if (!(left.Value is float leftValue))
                        return default;

                    if (!(rValue.Value is float rightValue))
                        return default;

                    return Unit.New(
                            value: leftValue + rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default;
                }
            );
        }

        public static UnitValue<TValue, TUnit> Subtract<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            return lhs.Binary(
                rhs,
                (left, right) =>
                {
                    var rValue = Convert(rhs, lhs.Unit);

                    if (!(left.Value is float leftValue))
                        return default;

                    if (!(rValue.Value is float rightValue))
                        return default;

                    return Unit.New(
                            value: leftValue - rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default;
                }
            );
        }

        public static UnitValue<TValue, TUnit> Multiply<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            return lhs.Binary(
                rhs,
                (left, right) =>
                {
                    var rValue = Convert(rhs, lhs.Unit);

                    if (!(left.Value is float leftValue))
                        return default;

                    if (!(rValue.Value is float rightValue))
                        return default;

                    return Unit.New(
                            value: leftValue * rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default;
                }
            );
        }

        public static UnitValue<TValue, TUnit> Divide<TValue, TUnit>
        (
            this UnitValue<TValue, TUnit> lhs,
            UnitValue<TValue, TUnit> rhs
        )
            where TUnit : struct
            where TValue : struct, IEquatable<TValue>
        {
            return lhs.Binary(
                rhs,
                (left, right) =>
                {
                    var rValue = Convert(rhs, lhs.Unit);

                    if (!(left.Value is float leftValue))
                        return default;

                    if (!(rValue.Value is float rightValue))
                        return default;

                    return Unit.New(
                            value: leftValue / rightValue as TValue?,
                            unit: left.Unit
                        )
                        ?? default;
                }
            );
        }

        //    public static UnitValue<TValue, TUnit> Add<TValue, TUnit>(
        //        this UnitValue<TValue, TUnit> lhs,
        //        UnitValue<TValue, TUnit> rhs)

        //        where TValue : struct, IEquatable<TValue>
        //        where TUnit : struct
        //    {
        //        var rightValue = rhs.Value;
        //        var rightUnit = rhs.Unit;

        //        switch (lhs)
        //        {
        //            case UnitValue<float, MassUnit> massLeft:
        //                {
        //                    var leftValue = massLeft.Value ?? 0;
        //                    var leftUnit = massLeft.Unit;

        //                    if (!(rightUnit is MassUnit rightUnitNew))
        //                    {
        //                        return default;
        //                    }

        //                    if (!(Unit.Mass(rightValue as float?, rightUnitNew) is { } massRight))
        //                    {
        //                        return default;
        //                    }

        //                    var rightValueNew = Mass.Instance.GetUnitConverter(massRight, leftUnit);

        //                    var resultValue = leftValue + rightValueNew.Value as TValue?;
        //                    var resultUnit = lhs.Unit;

        //                    return Unit.New(resultValue, resultUnit) ?? default;
        //                }

        //            case UnitValue<float, TimeUnit> timeLeft:
        //                {
        //                    var leftValue = timeLeft.Value ?? 0;
        //                    var leftUnit = timeLeft.Unit;

        //                    if (!(Unit.Time(rightValue as float?, leftUnit) is { } timeRight))
        //                    {
        //                        return default;
        //                    }

        //                    var rightValueNew = Time.Instance.GetUnitConverter(timeRight, leftUnit);

        //                    var resultValue = leftValue + rightValueNew.Value as TValue?;
        //                    var resultUnit = lhs.Unit;

        //                    return Unit.New(resultValue, resultUnit) ?? default;
        //                }
        //        }

        //        return default;
        //    }
        //}

    }

}