using System;

using JetBrains.Annotations;

namespace DataRug
{
    /// <summary>
    /// Represents information about the consumption of a consumable object.
    /// </summary>
    public readonly struct ConsumptionInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ConsumptionInfo" /> class.
        /// </summary>
        public ConsumptionInfo([NotNull] IConsumable consumed, float? amount, DateTime? consumedAt)
        {
            Consumed = consumed;
            Amount = amount;
            ConsumedAt = consumedAt;
        }


        /// <summary>
        /// Gets the object that was consumed.
        /// </summary>
        public IConsumable Consumed { get; }


        /// <summary>
        /// Gets the amount that was consumed.
        /// </summary>
        public float? Amount { get; }

        /// <summary>
        /// Gets the time at which the object was consumed.
        /// </summary>
        public DateTime? ConsumedAt { get; }
    }

}