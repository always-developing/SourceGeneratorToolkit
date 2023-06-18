using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensiosn for enums
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// Adds an enum to the contaioner
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="enumName">The name of the enum</param>
        /// <param name="builder">The builder used to modify the properties of the enum</param>
        /// <returns>The namespace container</returns>
        public static TContainer WithEnum<TContainer>(this ISupportsEnums<TContainer> @base, string enumName, Action<EnumContainer> builder) where TContainer : SourceContainer
        {
            var enumContainer = new EnumContainer(enumName, ((SourceContainer)@base).Configuration);
            enumContainer.AddBuildConfigurationOptions();

            ((SourceContainer)@base)._sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds an enum to the container, specifying the enum type
        /// </summary>
        /// <typeparam name="TContainer">The parent container</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="enumName">The name of the enum</param>
        /// <param name="type">The type of the enum</param>
        /// <param name="builder">The builder used to modify the properties of the enum</param>
        /// <returns>The namespace container</returns>
        public static TContainer WithEnum<TContainer>(this ISupportsEnums<TContainer> @base, string enumName, string type, Action<EnumContainer> builder) where TContainer : SourceContainer
        {
            var enumContainer = new EnumContainer(enumName, type, ((SourceContainer)@base).Configuration);
            enumContainer.AddBuildConfigurationOptions();

            ((SourceContainer)@base)._sourceItems.Add(enumContainer);
            builder.Invoke(enumContainer);

            return (TContainer)@base;
        }
    }
}
