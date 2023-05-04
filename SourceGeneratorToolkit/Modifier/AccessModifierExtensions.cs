namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for access modifiers
    /// </summary>
    public static class AccessModifierExtensions
    {
        /// <summary>
        /// Adds the public modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsPublic<TContainer>(this IPublicModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsPublic((TContainer)@base);
        }

        /// <summary>
        /// Adds the private modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsPrivate<TContainer>(this IPrivateModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsPrivate((TContainer)@base);
        }

        /// <summary>
        /// Adds the protected modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsProtected<TContainer>(this IProtectedModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsProtected((TContainer)@base);
        }

        /// <summary>
        /// Adds the internal modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsInternal<TContainer>(this IInternalModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsInternal((TContainer)@base);
        }

        /// <summary>
        /// Adds the protected internal modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsProtectedInternal<TContainer>(this IProtectedInternalModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsProtectedInternal((TContainer)@base);
        }

        /// <summary>
        /// Adds the private protected modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsPrivateProtected<TContainer>(this IPrivateProtectedModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsPrivateProtected((TContainer)@base);
        }

        /// <summary>
        /// Adds the file modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsFile<TContainer>(this IFileModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.AccessModifier.AsFile((TContainer)@base);
        }
    }
}
