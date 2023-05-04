namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing the async modifier
    /// </summary>
    public class AsyncModifierStatement : SourceStatement
    {
        /// <inheritdoc/>
        internal override string Name => nameof(AsyncModifierStatement);

        internal readonly bool _enforceTaskReturnType;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="enforceTaskReturnType">Flag to enforce the return type to be wrapped in Task</param>
        public AsyncModifierStatement(bool enforceTaskReturnType = true)
        {
            SourceText = "async ";
            Order = 10;
            _enforceTaskReturnType = enforceTaskReturnType;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            return SourceText;
        }
    }
}