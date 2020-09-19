namespace DataRug
{

    /// <summary>
    /// Defines functionality for an effect induced by a substance.
    /// </summary>
    public interface IEffect : IEntity
    {
        /// <summary>
        /// Gets the pool that the <see cref="IEffect"/> belongs to.
        /// </summary>
        EffectPool Pool { get; }

        /// <summary>
        /// Gets the polarity of the <see cref="IEffect"/>.
        /// </summary>
        /// <remarks>
        /// This determines whether the effect is generally seen as positive, negative or neutral.
        /// </remarks>
        EffectPolarity Polarity { get; }
    }

}