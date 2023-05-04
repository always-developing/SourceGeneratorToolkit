using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Container representing a method return type
    /// </summary>
    public class ReturnContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ReturnContainer);

        private const string VoidReturnType = "void";

        private bool _enforceAsync = false;

        /// <summary>
        /// Constructor for ReturnContainer
        /// </summary>
        public ReturnContainer()
        {
            SourceText = VoidReturnType;
        }

        /// <summary>
        /// Constructor for ReturnContainer
        /// </summary>
        /// <param name="returnType">The return type</param>
        public ReturnContainer(string returnType)
        {
            SourceText = returnType;
        }

        /// <summary>
        /// Constructor for ReturnContainer
        /// </summary>
        /// <param name="returnType">The return type</param>
        public ReturnContainer(Type returnType)
        {
            SourceText = returnType.Name;
        }

        /// <summary>
        /// Forces the return type of the method to be wrapped in a "Task"
        /// </summary>
        /// <param name="enforceAsync"></param>
        public void EnforceAsync(bool enforceAsync)
        {
            _enforceAsync = enforceAsync;
        }

        /// <inheritdoc/>
        public override string ToSource()
        {
            if (!_enforceAsync)
            {
                _sourceItems.Add(new Statement(SourceText));
                _sourceItems.Add(new EmptySpaceStatement());

                return base.ToSource();
            }

            _sourceItems.Add(SourceText == VoidReturnType ? new TaskStatement() : new TaskStatement(SourceText));
            _sourceItems.Add(new EmptySpaceStatement());

            return base.ToSource();
        }
    }
}
