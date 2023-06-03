using Microsoft.CodeAnalysis;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Qualifier for parameters
    /// </summary>
    public class ParameterQualifierBuilder : QualfierBuilder, INameQualifier<ParameterQualifierBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node being tested for qualification</param>
        /// <param name="qualifies">Bool to indicate the starting qualification state</param>
        public ParameterQualifierBuilder(SyntaxNode node, bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }
    }
}
