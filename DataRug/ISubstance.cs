using System.Collections.Generic;

using JetBrains.Annotations;

namespace DataRug
{

    /// <summary>
    /// Defines functionality for an object that is a substance such as a drug.
    /// </summary>
    public interface ISubstance : IEntity, IConsumable
    {
        /// <summary>
        /// Gets the category in which the <see cref="ISubstance"/> is categorized.
        /// </summary>
        SubstanceCategory Category { get; }

        /// <summary>
        /// Gets the available routes of administration for the <see cref="ISubstance"/>.
        /// </summary>
        IReadOnlyDictionary<SubstanceRoute, SubstanceRouteInfo> Routes { get; }


        /// <summary>
        /// Determines whether the <see cref="ISubstance"/> can be administered through the specified route.
        /// </summary>
        /// <param name="route">The route to check.</param>
        /// <returns><c>true</c> if the substance can be administered through the specified route; otherwise, <c>false</c>.</returns>
        bool CanAdminister([NotNull] SubstanceRoute route);

    }

}