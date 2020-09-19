using System.Collections.Generic;
using System.Linq;

using DataRug.API.Common.Entities;
using DataRug.Common.Data;

using JetBrains.Annotations;

namespace DataRug.Common.Entities
{

    /// <summary>
    /// Represents an object with a unique identity.
    /// </summary>
    public abstract class Entity : IEntity
    {
        private readonly List <Tag> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Entity" /> class.
        /// </summary>
        protected Entity(ulong? id)
        {
            _tags = new List <Tag>();
            Id = id;
        }


        /// <summary>
        /// Gets the unique identifier of the <see cref="Entity"/>.
        /// </summary>
        public ulong? Id { get; }

        /// <summary>
        /// Gets or sets the name of the <see cref="Entity"/>.
        /// </summary>
        public string Name { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Entity"/> has a null state.
        /// </summary>
        public bool IsNull => Id is null;


        /// <summary>
        /// Gets the tags of the object.
        /// </summary>
        public IReadOnlyList <Tag> Tags => _tags;


        /// <summary>
        /// Adds the specified tags to the <see cref="Entity"/>.
        /// </summary>
        /// <param name="tags">The tags to add.</param>
        public void AddTags([NotNull] params string[] tags)
        {
            foreach (var tag in tags)
            {
                _tags.Add(new Tag(tag));
            }
        }


        /// <summary>
        /// Returns a value indicating whether the object has a particular tag.
        /// </summary>
        /// <param name="value">The tag to find.</param>
        /// <returns><c>true</c> if the tag was found; otherwise, <c>false</c>.</returns>
        public bool HasTag(string value)
        {
            return Tags.Any(x => string.Equals(x.Value, value));
        }
    }

}