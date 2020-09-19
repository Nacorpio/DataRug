using JetBrains.Annotations;

namespace DataRug
{
    /// <summary>
    /// Represents a tag that can be added to an entity, used to represent traits and flags.
    /// </summary>
    public readonly struct Tag
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tag"/> structure.
        /// </summary>
        /// <param name="value"></param>
        public Tag([NotNull] string value)
        {
            Value = value.ToLower();
        }

        /// <summary>
        /// Gets the value of the <see cref="Tag"/>.
        /// </summary>
        public string Value { get; }
    }

}