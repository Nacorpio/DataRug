namespace DataRug.Common.Data
{

    public class SubstanceLevelInfo
    {
        public SubstanceLevelInfo(DurationRange duration, DoseRange dose)
        {
            Duration = duration;
            Dose = dose;
        }

        public DurationRange Duration { get; }
        public DoseRange Dose { get; }
    }

}