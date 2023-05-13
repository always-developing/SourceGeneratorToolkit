namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Static class containing extensiosn for generics
    /// </summary>
    public static class GenericExtensions
    {
        /// <summary>
        /// Adds a generic to the parent
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="value">The generic value</param>
        /// <returns>The parent container</returns>
        public static TContainer AddGeneric<TContainer>(this ISupportsGenerics<TContainer> @base, string value) where TContainer : SourceContainer
        {
            @base.GenericList.AddGeneric(value);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a generic constraint to the parent
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="generic">The generic value the constraint applies to</param>
        /// <param name="constraint">The generic constraint value</param>
        /// <returns>The parent container</returns>
        public static TContainer WithGenericConstraint<TContainer>(this ISupportsGenericsConstraints<TContainer> @base, string generic, string constraint) where TContainer : SourceContainer
        {
            @base.ConstraintContainer.AddConstraint(generic, constraint);

            return (TContainer)@base;
        }

        /// <summary>
        /// Adds a generic constraint to the parent
        /// </summary>
        /// <typeparam name="TContainer">The parent container type</typeparam>
        /// <param name="base">The parent container</param>
        /// <param name="generic">The generic value the constraint applies to</param>
        /// <param name="constraint">The generic constraint value</param>
        /// <returns>The parent container</returns>
        public static TContainer WithGenericConstraint<TContainer>(this ISupportsGenericsConstraints<TContainer> @base, string generic, GenericConstraint constraint) where TContainer : SourceContainer
        {
            @base.ConstraintContainer.AddConstraint(generic, GetStrigConstraint(constraint));

            return (TContainer)@base;
        }

        private static string GetStrigConstraint(GenericConstraint constraint) => constraint switch
        {
            GenericConstraint.Struct => "struct",
            GenericConstraint.Class => "class",
            GenericConstraint.NullableClass => "class?",
            GenericConstraint.NotNull => "notnull",
            GenericConstraint.Default => "default",
            GenericConstraint.Unmanaged => "unmanaged",
            GenericConstraint.New => "new()",
            _ => constraint.ToString()
        };
    }
}
