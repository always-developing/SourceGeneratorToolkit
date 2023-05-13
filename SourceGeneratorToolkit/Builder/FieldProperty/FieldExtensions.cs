using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the field container
    /// </summary>
    public static class FieldExtensions
    {
        /// <summary>
        /// Adds a field to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The field type</param>
        /// <param name="name">The field name</param>
        /// <param name="builder">The builder used to modify the properties of a field</param>
        /// <returns>The parent container</returns>
        public static TContainer AddField<TContainer>(this ISupportsField<TContainer> @base, string type, string name, Action<FieldContainer> builder = null) where TContainer : SourceContainer
        {
            @base.Fields.AddField(type, name, builder);
            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a field to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The field type</param>
        /// <param name="name">The field name</param>
        /// <param name="builder">The builder used to modify the properties of a field</param>
        /// <returns>The parent container</returns>
        public static TContainer AddField<TContainer>(this ISupportsField<TContainer> @base, Type type, string name, Action<FieldContainer> builder = null) where TContainer : SourceContainer
        {
            @base.Fields.AddField(type.Name, name, builder);
            return (TContainer)@base;
        }
    }
}
