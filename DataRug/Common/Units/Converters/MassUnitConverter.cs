using MassUnitValue = DataRug.Common.Units.UnitValue<float, DataRug.Common.Units.MassUnit>;

namespace DataRug.Common.Units.Converters
{

    public class MassUnitConverter : BaseUnitConverter<float, MassUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MassUnitConverter" /> class.
        /// </summary>
        public MassUnitConverter() : base(_)
        {
        }

        private static MassUnitValue? _(MassUnitValue input, MassUnit massUnit)
        {
            return input.Unit switch
            {
                MassUnit.Micrograms => _ConvertMicrograms(input, massUnit),
                MassUnit.Grams => _ConvertGrams(input, massUnit),
                MassUnit.Milligrams => _ConvertMilligrams(input, massUnit),

                _ => null
            };
        }

        private static MassUnitValue? _ConvertMilligrams(in MassUnitValue input, MassUnit massUnit)
        {
            return massUnit switch
            {
                MassUnit.Milligrams => input,
                MassUnit.Micrograms => Unit.Mass(input.Value * 1000, MassUnit.Micrograms),
                MassUnit.Grams => Unit.Mass(input.Value / 1000, MassUnit.Grams),
                _ => null
            };
        }

        private static MassUnitValue? _ConvertMicrograms(in MassUnitValue input, MassUnit massUnit)
        {
            return massUnit switch
            {
                MassUnit.Micrograms => input,
                MassUnit.Milligrams => Unit.Mass(input.Value / 1000, MassUnit.Milligrams),
                MassUnit.Grams => Unit.Mass(input.Value / 1000 / 1000, MassUnit.Grams),
                _ => null
            };
        }

        private static MassUnitValue? _ConvertGrams(in MassUnitValue input, MassUnit massUnit)
        {
            return massUnit switch
            {
                MassUnit.Grams => input,
                MassUnit.Milligrams => Unit.Mass(input.Value * 1000, MassUnit.Milligrams),
                MassUnit.Micrograms => Unit.Mass(input.Value * 1000 * 1000, MassUnit.Micrograms),
                _ => null
            };
        }
    }

}