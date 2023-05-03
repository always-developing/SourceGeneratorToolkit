using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for the property container
    /// </summary>
    public static class PropertyExtensions
    {
        /// <summary>
        /// Adds a property to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The property type</param>
        /// <param name="name">The property name</param>
        /// <param name="builder">The builder used to modify the properties of the class constructor</param>
        /// <returns>The parent container</returns>
        public static TContainer AddProperty<TContainer>(this ISupportsProperty<TContainer> @base, string type, string name, Action<PropertyContainer> builder = null) where TContainer : SourceContainer
        {
            @base.Properties.AddProperty(type, name, builder);
            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a property to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The property type</param>
        /// <param name="name">The property name</param>
        /// <param name="builder">The builder used to modify the properties of the class constructor</param>
        /// <returns>The parent container</returns>
        public static TContainer AddProperty<TContainer>(this ISupportsProperty<TContainer> @base, Type type, string name, Action<PropertyContainer> builder = null) where TContainer : SourceContainer
        {
            @base.Properties.AddProperty(type.Name, name, builder);
            return (TContainer)@base;
        }
    }
}
