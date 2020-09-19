namespace DataRug.API.Common.Entities
{

    /// <summary>
    /// Defines functionality for an object with a unique identity.
    /// </summary>
    public interface IEntity : IUnique, INamed, ITagged
    {
    }

}