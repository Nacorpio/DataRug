using System;

using DataRug.API.Common.Entities;
using DataRug.Common.Data;

using JetBrains.Annotations;

namespace DataRug.Common
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