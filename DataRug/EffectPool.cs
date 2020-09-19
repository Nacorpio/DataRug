namespace DataRug
{

    /// <summary>
    /// Represents a pool that an effect can belong to.
    /// </summary>
    public enum EffectPool
    {
        /// <summary>
        /// Signifies that the effect affects the host physically.
        /// </summary>
        Physical,

        /// <summary>
        /// Signifies that the effect affects the host cognitively.
        /// </summary>
        Cognitive,

        /// <summary>
        /// Signifies that the effect affects the host visually.
        /// </summary>
        Visual,

        /// <summary>
        /// Signifies that the effect affects the host auditorily.
        /// </summary>
        Auditory,

        /// <summary>
        /// Signifies that the effect is transpersonal.
        /// </summary>
        Transpersonal,

        /// <summary>
        /// Signifies that the effect is multi-sensory.
        /// </summary>
        MultiSensory,
    }

}