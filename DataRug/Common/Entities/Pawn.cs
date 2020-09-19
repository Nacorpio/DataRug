using System;

using DataRug.API.Common;
using DataRug.API.Common.Entities;
using DataRug.Common.Data;

namespace DataRug.Common.Entities
{
    /// <summary>
    /// Represents an object on which 
    /// </summary>
    public class Pawn : Entity, IPawn
    {
        /// <summary>
        /// Raised when the <see cref="IPawn"/> has consumed something.
        /// </summary>
        public event EventHandler<PawnConsumedEventArgs> Consumed;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Object" /> class.
        /// </summary>
        public Pawn(ulong? id) : base(id)
        {
            LastConsumed = null;
        }

        /// <summary>
        /// Gets information about the last time the <see cref="IPawn"/> consumed something.
        /// </summary>
        public ConsumptionInfo? LastConsumed { get; private set; }

        /// <summary>
        /// Makes the <see cref="IPawn"/> consume the specified object, specifying the amount.
        /// </summary>
        /// <param name="consumable">The object that the host should consume.</param>
        /// <param name="amount">The amount that was consumed.</param>
        /// <returns>Information about the consumption that took place, if successful; otherwise, <c>null</c>.</returns>
        public ConsumptionInfo? Consume(IConsumable consumable, float amount)
        {
            var cInfo = new ConsumptionInfo(consumable, amount, DateTime.Now);
            LastConsumed = cInfo;

            OnConsumed(new PawnConsumedEventArgs(this, cInfo));

            return cInfo;
        }

        protected virtual void OnConsumed(PawnConsumedEventArgs e)
        {
            Consumed?.Invoke(this, e);
        }
    }

}