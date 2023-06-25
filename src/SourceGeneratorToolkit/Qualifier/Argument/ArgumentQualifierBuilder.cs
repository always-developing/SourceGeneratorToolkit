using Microsoft.CodeAnalysis;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Qualifier for arguments
    /// </summary>
    public class ArgumentQualifierBuilder : QualfierBuilder, INameQualifier<ArgumentQualifierBuilder>, 
        IArgumentQualifier<ArgumentQualifierBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node being tested for qualification</param>
        /// <param name="qualifies">Bool to indicate the starting qualification state</param>
        public ArgumentQualifierBuilder(SyntaxNode node,  bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }
    }
}
