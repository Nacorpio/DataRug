using DataRug.API.Common.Collections;
using DataRug.API.Common.Entities;

namespace DataRug.API.Common
{
    /// <summary>
    /// Defines functionality for an object that can be consumed by a pawn.
    /// </summary>
    public interface IConsumable
    {
        /// <summary>
        /// Gets the effects that the object induces.
        /// </summary>
        IReadOnlyUniqueMap <IEffect> Effects { get; }
    }

}