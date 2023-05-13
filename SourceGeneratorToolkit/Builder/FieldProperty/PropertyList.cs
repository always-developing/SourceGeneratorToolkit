using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a collection of properties on a container
    /// </summary>
    public class PropertyList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ArgumentList);

        /// <summary>
        /// Adds a property to the containert
        /// </summary>
        /// <param name="type">The property type</param>
        /// <param name="name">The property name</param>
        /// <param name="builder">The builder used to modify the properties of the property</param>
        /// <returns>The property container</returns>
        public PropertyContainer AddProperty(string type, string name, Action<PropertyContainer> builder = null)
        {
            var propContainer = new PropertyContainer(type, name);
            _sourceItems.Add(propContainer);

            builder?.Invoke(propContainer);

            return propContainer;
        }
    }
}
