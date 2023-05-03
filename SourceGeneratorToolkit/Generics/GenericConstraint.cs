namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Enum for generic constraints
    /// </summary>
    public enum GenericConstraint
    {
        /// <summary>
        /// Constraint is a struct
        /// </summary>
        Struct,
        /// <summary>
        /// Constraint is a class
        /// </summary>
        Class,
        /// <summary>
        /// Constraint is a nullable class
        /// </summary>
        NullableClass,
        /// <summary>
        /// Constraint is non-nullable
        /// </summary>
        NotNull,
        /// <summary>
        /// Constraint is non-nullable
        /// </summary>
        Default,
        /// <summary>
        /// Constraint is unmanaged
        /// </summary>
        Unmanaged,
        /// <summary>
        /// Constraint can be newed
        /// </summary>
        New
    }
}
