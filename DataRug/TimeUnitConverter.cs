using TimeUnitValue = DataRug.UnitValue<float, DataRug.TimeUnit>;

namespace DataRug
{

    public class TimeUnitConverter : BaseUnitConverter<float, TimeUnit>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeUnitConverter" /> class.
        /// </summary>
        public TimeUnitConverter() : base(_)
        {
        }

        private static TimeUnitValue? _(TimeUnitValue input, TimeUnit unit)
        {
            return input.Unit switch
            {
                TimeUnit.Days => _ConvertDays(input, unit),
                TimeUnit.Hours => _ConvertHours(input, unit),
                TimeUnit.Minutes => _ConvertMinutes(input, unit),
                TimeUnit.Seconds => _ConvertSeconds(input, unit),

                _ => null
            };
        }

        private static TimeUnitValue _ConvertSeconds(in TimeUnitValue input, TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Seconds: return input;
                case TimeUnit.Minutes: return Unit.Time(input.Value / 60, TimeUnit.Minutes) ?? default;
                case TimeUnit.Hours: return Unit.Time(input.Value / 60 / 60, TimeUnit.Hours) ?? default;
                case TimeUnit.Days: return Unit.Time(input.Value / 24 / 60 / 60, TimeUnit.Days) ?? default;

                case TimeUnit.Undefined: break;

                default: return default;
            }

            return default;
        }

        private static TimeUnitValue _ConvertMinutes(in TimeUnitValue input, TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Minutes: return input;
                case TimeUnit.Seconds: return Unit.Time(input.Value * 60, TimeUnit.Seconds) ?? default;
                case TimeUnit.Hours: return Unit.Time(input.Value / 60, TimeUnit.Hours) ?? default;
                case TimeUnit.Days: return Unit.Time(input.Value / 24 / 60, TimeUnit.Days) ?? default;

                case TimeUnit.Undefined: break;

                default: return default;
            }

            return default;
        }

        private static TimeUnitValue _ConvertDays(TimeUnitValue input, TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Days: return input;
                case TimeUnit.Hours: return Unit.Time(input.Value * 24, TimeUnit.Hours) ?? default;
                case TimeUnit.Minutes: return Unit.Time(input.Value * 24 * 60, TimeUnit.Minutes) ?? default;
                case TimeUnit.Seconds: return Unit.Time(input.Value * 24 * 60 * 60, TimeUnit.Seconds) ?? default;
                case TimeUnit.Undefined: break;

                default: return default;
            }

            return default;
        }

        private static TimeUnitValue _ConvertHours(TimeUnitValue input, TimeUnit unit)
        {
            switch (unit)
            {
                case TimeUnit.Hours: return input;
                case TimeUnit.Days: return Unit.Time(input.Value / 24, TimeUnit.Days) ?? default;
                case TimeUnit.Minutes: return Unit.Time(input.Value * 60, TimeUnit.Minutes) ?? default;
                case TimeUnit.Seconds: return Unit.Time(input.Value * 60 * 60, TimeUnit.Seconds) ?? default;

                case TimeUnit.Undefined: break;

                default: return default;
            }

            return default;
        }
    }

}