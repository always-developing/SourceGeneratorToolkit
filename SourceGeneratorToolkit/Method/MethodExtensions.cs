using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for methods
    /// </summary>
    public static class MethodExtensions
    {
        /// <summary>
        /// Adds a method to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// <returns>The parent container</returns>
        public static TContainer WithMethod<TContainer>(this ISupportsMethods<TContainer> @base, string methodName, string returnType) where TContainer : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new MethodContainer(methodName, returnType));

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a method to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// <returns>The parent container</returns>
        public static TContainer WithMethod<TContainer>(this ISupportsMethods<TContainer> @base, string methodName, Type returnType) where TContainer : SourceContainer
        {
            ((SourceContainer)@base)._sourceItems.Add(new MethodContainer(methodName, returnType));

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a method to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// /// <param name="builder">The builder used to modify the properties of the method</param>
        /// <returns>The parent container</returns>
        public static TContainer WithMethod<TContainer>(this ISupportsMethods<TContainer> @base, string methodName, string returnType, Action<MethodContainer> builder) where TContainer : SourceContainer
        {
            var container = new MethodContainer(methodName, returnType);
            ((SourceContainer)@base)._sourceItems.Add(container);

            builder.Invoke(container);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a method to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="methodName">The method name</param>
        /// <param name="returnType">The method return type</param>
        /// /// <param name="builder">The builder used to modify the properties of the method</param>
        /// <returns>The parent container</returns>
        public static TContainer WithMethod<TContainer>(this ISupportsMethods<TContainer> @base, string methodName, Type returnType, Action<MethodContainer> builder) where TContainer : SourceContainer
        {
            var container = new MethodContainer(methodName, returnType);
            ((SourceContainer)@base)._sourceItems.Add(container);

            builder.Invoke(container);

            return (TContainer)@base;
        }
    }
}
