using Microsoft.CodeAnalysis;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// The base syntax qualifier builder
    /// </summary>
    public class SyntaxQualifierBuilder : QualfierBuilder
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="syntaxNode">The syntax node</param>
        public SyntaxQualifierBuilder(SyntaxNode syntaxNode)
        {
            Node = syntaxNode;
        }
    }
}
