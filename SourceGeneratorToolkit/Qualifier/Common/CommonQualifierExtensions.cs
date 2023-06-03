using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extensions for common functions used across node types
    /// </summary>
    public static class CommonQualifierExtensions
    {
        /// <summary>
        /// Checks to determine if the name of the syntax (class, method) matches the supplied name
        /// </summary>
        /// <typeparam name="TParent">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="name">The name of the syntax node</param>
        /// <param name="comparison">The string comparison to be applied when checking the return types</param>
        /// <returns>The qualifier builder</returns>
        public static TParent WithName<TParent>(this INameQualifier<TParent> syntaxBuilder, string name, 
            StringComparison comparison = StringComparison.InvariantCultureIgnoreCase)
            where TParent : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TParent)syntaxBuilder;
            }

            qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && name.Equals(GetNodeIdentifier(qualifierBuilder.Node), comparison);

            return (TParent)syntaxBuilder;
        }

        private static string GetNodeIdentifier(SyntaxNode node) =>
            node switch
            {
                TypeDeclarationSyntax baseDeclaration => baseDeclaration.Identifier.ValueText,
                MethodDeclarationSyntax methodDeclaration => methodDeclaration.Identifier.ValueText,
                AttributeSyntax attributeDeclaration => attributeDeclaration.Name.ToString(),
                AttributeArgumentSyntax attributeArgument => attributeArgument.NameColon == null ? string.Empty : attributeArgument.NameColon.Name.Identifier.ValueText,
                null => string.Empty,
                _ => string.Empty
            };
    }
}
