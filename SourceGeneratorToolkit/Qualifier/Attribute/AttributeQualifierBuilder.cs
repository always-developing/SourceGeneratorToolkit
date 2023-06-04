using Microsoft.CodeAnalysis;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Qualifier for attributes
    /// </summary>
    public class AttributeQualifierBuilder : QualfierBuilder, INameQualifier<AttributeQualifierBuilder>,
        IHasArgumentQualifier<AttributeQualifierBuilder>, IAttributeQualifier<AttributeQualifierBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node being tested for qualification</param>
        /// <param name="qualifies">Bool to indicate the starting qualification state</param>
        public AttributeQualifierBuilder(SyntaxNode node, bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }
    }
}
