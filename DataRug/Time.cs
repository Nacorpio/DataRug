﻿using TimeUnitValue = DataRug.UnitValue <float, DataRug.TimeUnit>;

namespace DataRug
{

    public static class Time
    {
        static Time()
        {
            Instance = new TimeUnitConverter();
        }

        public static TimeUnitConverter Instance { get; }

        public static TimeUnitValue Seconds(int value)
        {
            return new TimeUnitValue(value, TimeUnit.Seconds);
        }

        public static TimeUnitValue Minutes(int value)
        {
            return new TimeUnitValue(value, TimeUnit.Minutes);
        }

        public static TimeUnitValue Hours(int value)
        {
            return new TimeUnitValue(value, TimeUnit.Hours);
        }

        public static TimeUnitValue Days(int value)
        {
            return new TimeUnitValue(value, TimeUnit.Days);
        }
    }

}