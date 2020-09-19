using System.Collections.Generic;

using DataRug.API.Common.Collections;
using DataRug.API.Common.Entities;
using DataRug.Common.Collections;
using DataRug.Common.Data;
using DataRug.Common.Enums;
using DataRug.Common.Units;

using JetBrains.Annotations;

namespace DataRug.Common.Entities
{
    /// <summary>
    /// Represents an object that can be consumed and induce effects.
    /// </summary>
    public class Substance : Entity, ISubstance
    {
        private readonly UniqueMap<IEffect> _effectMap;
        private readonly Dictionary<SubstanceRoute, SubstanceRouteInfo> _routes;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Entity" /> class.
        /// </summary>
        public Substance(ulong? id) : base(id)
        {
            _effectMap = new UniqueMap<IEffect>();
            _routes = new Dictionary<SubstanceRoute, SubstanceRouteInfo>();
        }


        /// <summary>
        /// Gets the category in which the <see cref="ISubstance"/> is categorized.
        /// </summary>
        public SubstanceCategory Category { get; internal set; }


        /// <summary>
        /// Gets the effects that the <see cref="ISubstance"/> can induce.
        /// </summary>
        public IReadOnlyUniqueMap<IEffect> Effects => _effectMap;

        /// <summary>
        /// Gets the available routes of administration for the <see cref="ISubstance"/>.
        /// </summary>
        public IReadOnlyDictionary<SubstanceRoute, SubstanceRouteInfo> Routes => _routes;


        public SubstanceRouteInfo GetRoute([NotNull] SubstanceRoute route)
        {
            return _routes.TryGetValue(route, out var r) ? r : null;
        }

        /// <summary>
        /// Determines whether the <see cref="ISubstance"/> can be administered through the specified route.
        /// </summary>
        /// <param name="route">The route to check.</param>
        /// <returns><c>true</c> if the substance can be administered through the specified route; otherwise, <c>false</c>.</returns>
        public bool CanAdminister(SubstanceRoute route)
        {
            return Routes.ContainsKey(route);
        }


        public DurationRange? GetDurationRange
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            return !(_routes.TryGetValue(
                    route,
                    out var sri
                )
                && sri.GetDurationRange(doseLevel) is DurationRange dr)
                ? default
                : dr;
        }

        public DoseRange? GetDoseRange
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            return !(_routes.TryGetValue(
                    route,
                    out var sri
                )
                && sri.GetDoseRange(doseLevel) is DoseRange dr)
                ? default
                : dr;
        }

        public UnitValue<float, MassUnit> GetMaxDose
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            var doseRange = GetDoseRange(route, doseLevel);

            return !(doseRange?.Unit is MassUnit mu)
                ? default
                : new UnitValue<float, MassUnit>(doseRange.Value.Maximum, mu);
        }

        public UnitValue<float, MassUnit> GetMinDose
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            var doseRange = GetDoseRange(route, doseLevel);

            return !(doseRange?.Unit is MassUnit mu)
                ? default
                : new UnitValue<float, MassUnit>(doseRange.Value.Minimum, mu);
        }


        public UnitValue<int, TimeUnit> GetMaxDuration
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            var durationRange = GetDurationRange(route, doseLevel);

            return !(durationRange?.Unit is TimeUnit tu)
                ? default
                : new UnitValue<int, TimeUnit>(durationRange.Value.Maximum, tu);
        }

        public UnitValue<int, TimeUnit> GetMinDuration
            ([NotNull] SubstanceRoute route, [NotNull] SubstanceDoseLevel doseLevel)
        {
            var durationRange = GetDurationRange(route, doseLevel);

            return !(durationRange?.Unit is TimeUnit tu)
                ? default
                : new UnitValue<int, TimeUnit>(durationRange.Value.Minimum, tu);
        }
    }

}