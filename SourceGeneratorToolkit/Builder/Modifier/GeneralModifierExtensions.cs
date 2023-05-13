namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensions for general modifiers
    /// </summary>
    public static class GeneralModifierExtensions
    {
        /// <summary>
        /// Adds the static modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsStatic<TContainer>(this IStaticModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsStatic((TContainer)@base);
        }

        /// <summary>
        /// Adds the abstract modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsAbstract<TContainer>(this IAbstractModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsAbstract((TContainer)@base);
        }

        /// <summary>
        /// Adds the partial modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsPartial<TContainer>(this IPartialModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsPartial((TContainer)@base);
        }

        /// <summary>
        /// Adds the sealed modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsSealed<TContainer>(this ISealedModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsSealed((TContainer)@base);
        }

        /// <summary>
        /// Adds the readonly modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsReadOnly<TContainer>(this IReadOnlyModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsReadOnly((TContainer)@base);
        }

        /// <summary>
        /// Adds the virtual modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsVirtual<TContainer>(this IVirtualModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsVirtual((TContainer)@base);
        }

        /// <summary>
        /// Adds the override modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsOverride<TContainer>(this IOverrideModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsOverride((TContainer)@base);
        }

        /// <summary>
        /// Adds the unsafe modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsUnsafe<TContainer>(this IUnsafeModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsUnsafe((TContainer)@base);
        }
        /// <summary>
        /// Adds the async modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="enforceTaskReturnType">Flag to enforce the method return type to be wrapped in Task</param>
        /// <returns>The parent container</returns>

        public static TContainer AsAsync<TContainer>(this IAsyncModifier<TContainer> @base, bool enforceTaskReturnType = true) where TContainer : SourceContainer
        {
            if(@base as ISupportsReturnValue != null)
            {
                ((ISupportsReturnValue)@base).ReturnType.EnforceAsync(enforceTaskReturnType);
            }

            // TODO: something better here
            if (@base as InterfaceMethodContainer == null)
            {
                return @base.GeneralModifiers.AsAsync((TContainer)@base, enforceTaskReturnType);
            }

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds the required modifier to the parent container
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <returns>The parent container</returns>
        public static TContainer AsRequired<TContainer>(this IRequiredModifier<TContainer> @base) where TContainer : SourceContainer
        {
            return @base.GeneralModifiers.AsRequired((TContainer)@base);
        }
    }
}
