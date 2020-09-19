namespace DataRug
{
    /// <summary>
    /// Defines functionality for an object that stores a value.
    /// </summary>
    /// <typeparam name="T">The value type.</typeparam>
    public interface IValue <out T>
    {
        T Value { get; }
    }

    /// <summary>
    /// Represents an object that abstracts a multiplication factor.
    /// </summary>
    public readonly struct FactorValue : IValue <int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FactorValue"/> structure.
        /// </summary>
        /// <param name="baseValue">The base value.</param>
        /// <param name="factor">The multiplication factor value.</param>
        public FactorValue(int baseValue, int factor)
        {
            BaseValue = baseValue;
            Factor = factor;
        }

        /// <summary>
        /// Gets the base value of the <see cref="FactorValue"/>.
        /// </summary>
        /// <remarks>
        /// Note: This is the value which will be multiplied and returned in <see cref="Value"/>.
        /// </remarks>
        public int BaseValue { get; }

        /// <summary>
        /// Gets the multiplication factor of the <see cref="FactorValue"/>.
        /// </summary>
        public int Factor { get; }

        /// <summary>
        /// Gets the calculated value of the <see cref="FactorValue"/>.
        /// </summary>
        public int Value => BaseValue * Factor;
    }

}