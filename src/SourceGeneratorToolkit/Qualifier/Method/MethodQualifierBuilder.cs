using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Xml.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Qualifier for methods
    /// </summary>
    public class MethodQualifierBuilder : QualfierBuilder, IAccessModifierQualifier<MethodQualifierBuilder>,
        IGeneralModifierQualifier<MethodQualifierBuilder>, INameQualifier<MethodQualifierBuilder>,
        IHasAttributeQualifier<MethodQualifierBuilder>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="node">The node being tested for qualification</param>
        /// <param name="qualifies">Bool to indicate the starting qualification state</param>
        public MethodQualifierBuilder(SyntaxNode node, bool qualifies)
        {
            Node = node;
            Qualifies = qualifies;
        }

        /// <summary>
        /// Checks to determine if the return type of the method matches the specificed type
        /// </summary>
        /// <param name="returnType">The return type as a string</param>
        /// <param name="comparison">The string comparison to be applied when checking the return types</param>
        /// <returns>The MethodQualifierBuilder instance</returns>
        public MethodQualifierBuilder WithReturnType(string returnType, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (Node is MethodDeclarationSyntax memberDeclaration)
            {
                Qualifies = Qualifies && memberDeclaration.ReturnType.ToString().Equals(returnType, comparison);
            }

            return this;
        }

        /// <summary>
        /// Checks to determine if the return type of the method matches the specificed type
        /// </summary>
        /// <param name="returnType">The return type</param>
        /// <param name="comparison">The string comparison to be applied when checking the return types</param>
        /// <returns>The MethodQualifierBuilder instance</returns>
        public MethodQualifierBuilder WithReturnType(Type returnType, StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
        {
            if (Node is MethodDeclarationSyntax memberDeclaration)
            {
                Qualifies = Qualifies && memberDeclaration.ReturnType.ToString().Equals(returnType.Name, comparison);
            }

            return this;
        }
    }
}
