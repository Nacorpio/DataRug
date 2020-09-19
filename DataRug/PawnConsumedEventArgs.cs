using System;

using JetBrains.Annotations;

namespace DataRug
{

    public class PawnConsumedEventArgs : EventArgs
    {
        public PawnConsumedEventArgs([NotNull] IPawn pawn, [NotNull] ConsumptionInfo consumption)
        {
            Pawn        = pawn;
            Consumption = consumption;
        }

        public IPawn Pawn { get; }
        public ConsumptionInfo Consumption { get; }
    }

}