using MassUnitValue = DataRug.UnitValue <float, DataRug.MassUnit>;

namespace DataRug
{
    public static class Mass
    {
        static Mass()
        {
            Instance = new MassUnitConverter();
        }

        public static MassUnitConverter Instance { get; }

        public static MassUnitValue Micrograms(int value)
        {
            return new MassUnitValue(value, MassUnit.Micrograms);
        }

        public static MassUnitValue Milligrams(int value)
        {
            return new MassUnitValue(value, MassUnit.Milligrams);
        }

        public static MassUnitValue Grams(int value)
        {
            return new MassUnitValue(value, MassUnit.Grams);
        }
    }

}