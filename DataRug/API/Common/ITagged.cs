using System.Collections.Generic;

using DataRug.Common.Data;

namespace DataRug.API.Common
{

    /// <summary>
    /// Defines functionality for an object that can store tags.
    /// </summary>
    public interface ITagged
    {
        /// <summary>
        /// Gets the tags of the object.
        /// </summary>
        IReadOnlyList <Tag> Tags { get; }

        /// <summary>
        /// Returns a value indicating whether the object has a particular tag.
        /// </summary>
        /// <param name="value">The tag to find.</param>
        /// <returns><c>true</c> if the tag was found; otherwise, <c>false</c>.</returns>
        bool HasTag(string value);
    }

}