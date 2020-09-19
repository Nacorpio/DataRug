using System.Collections.Generic;

using JetBrains.Annotations;

namespace DataRug
{

    public class SubstanceRouteInfo
    {
        private readonly Dictionary<SubstanceDoseLevel, SubstanceLevelInfo> _levels;

        public SubstanceRouteInfo()
        {
            _levels = new Dictionary<SubstanceDoseLevel, SubstanceLevelInfo>();
        }

        public IReadOnlyDictionary<SubstanceDoseLevel, SubstanceLevelInfo> Levels => _levels;

        public SubstanceLevelInfo GetLevel([NotNull] SubstanceDoseLevel level)
        {
            return _levels.TryGetValue(level, out var l) ? l : null;
        }

        public DurationRange? GetDurationRange([NotNull] SubstanceDoseLevel level)
        {
            return GetLevel(level)?.Duration;
        }

        public DoseRange? GetDoseRange([NotNull] SubstanceDoseLevel level)
        {
            return GetLevel(level)?.Dose;
        }
    }

}