using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// A container representing a parameter
    /// </summary>
    public class ParameterContainer : SourceContainer
    {
        /// <inheritdoc/>
        internal override string Name => nameof(ParameterContainer);

        /// <summary>
        /// Adds a parameter to the container
        /// </summary>
        /// <param name="type">The parameter type</param>
        /// <param name="name">The parameter name</param>
        public void AddParameter(string type, string name) 
        {
            if(_sourceItems.Any())
            {
                _sourceItems.Add(new CommaStatement());
            }
            _sourceItems.Add(new ParameterStatement(type, name));
        }
    }
}
