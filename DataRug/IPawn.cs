using System;

using JetBrains.Annotations;

namespace DataRug
{

    /// <summary>
    /// Defines functionality for an object that simulates a person.
    /// </summary>
    public interface IPawn : IEntity
    {
        /// <summary>
        /// Raised when the <see cref="DataRug.IPawn"/> has consumed something.
        /// </summary>
        event EventHandler<PawnConsumedEventArgs> Consumed;


        /// <summary>
        /// Gets information about the last time the <see cref="DataRug.IPawn"/> consumed something.
        /// </summary>
        ConsumptionInfo? LastConsumed { get; }

        /// <summary>
        /// Makes the <see cref="IPawn"/> consume the specified object.
        /// </summary>
        /// <param name="consumable">The object that the pawn should consume.</param>
        /// <param name="amount">The amount that was consumed.</param>
        /// <returns>Information about the consumption that took place, if successful; otherwise, <c>null</c>.</returns>
        ConsumptionInfo? Consume([NotNull] IConsumable consumable, float amount);
    }

}