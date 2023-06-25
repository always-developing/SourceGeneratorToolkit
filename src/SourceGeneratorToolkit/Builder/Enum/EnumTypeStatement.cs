namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the enum type
    /// </summary>
    public class EnumTypeStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(EnumTypeStatement);

        /// <summary>
        /// Constructor for the EnumTypeStatement class
        /// </summary>
        /// <param name="type">The type of the enum</param>
        public EnumTypeStatement(string type)
        {
            SourceText = $" : {type}";
        }
    }
}
