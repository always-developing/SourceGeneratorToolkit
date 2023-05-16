using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for parameters
    /// </summary>
    public static class ParameterExtensions
    {
        /// <summary>
        /// Adds a parameter to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The parameter type</param>
        /// <param name="name">The parameter name</param>
        /// <param name="builder">The parameter builder</param>
        /// <returns>The parent container</returns>
        public static TContainer AddParameter<TContainer>(this ISupportsParameters<TContainer> @base, string type, string name, 
            Action<ParameterStatement> builder = null) where TContainer : SourceContainer
        {
            var param = @base.ParameterContainer.AddParameter(type, name);
            builder?.Invoke(param);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a parameter to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="type">The parameter type</param>
        /// <param name="name">The parameter name</param>
        /// <param name="builder">The parameter builder</param>
        /// <returns>The parent container</returns>
        public static TContainer AddParameter<TContainer>(this ISupportsParameters<TContainer> @base, Type type, string name,
            Action<ParameterStatement> builder = null) where TContainer : SourceContainer
        {
            var param = @base.ParameterContainer.AddParameter(type.Name, name);
            builder?.Invoke(param);

            return (TContainer)@base;
        }
    }
}
