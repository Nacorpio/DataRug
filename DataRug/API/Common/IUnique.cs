namespace DataRug.API.Common
{
    /// <summary>
    /// Defines functionality for an object with a unique identity.
    /// </summary>
    public interface IUnique
    {
        /// <summary>
        /// Gets the unique identifier of the object.
        /// </summary>
        ulong? Id { get; }

        /// <summary>
        /// Gets a value indicating whether the object has a null state.
        /// </summary>
        bool IsNull { get; }
    }

}