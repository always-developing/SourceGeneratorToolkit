using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a collection of fields on a container
    /// </summary>
    public class FieldList : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ArgumentList);

        /// <summary>
        /// Adds a field to the container
        /// </summary>
        /// <param name="type">The field type</param>
        /// <param name="name">The field name</param>
        /// <param name="builder">The builder used to modify the properties of the field</param>
        /// <returns>The field container</returns>
        public FieldContainer AddField(string type, string name, Action<FieldContainer> builder = null)
        {
            var fieldContainer = new FieldContainer(type, name);
            _sourceItems.Add(fieldContainer);

            builder?.Invoke(fieldContainer);

            return fieldContainer;
        }
    }
}
