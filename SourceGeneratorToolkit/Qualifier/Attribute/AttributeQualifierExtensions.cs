using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for attribute related qualifier
    /// </summary>
    public static class AttributeQualifierExtensions
    {
        /// <summary>
        /// Checks if the node has an attribute with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAttribute<TBuilder>(this IHasAttributeQualifier<TBuilder> syntaxBuilder, Action<AttributeQualifierBuilder> builder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var attributes = GetNodeAttributes(qualifierBuilder.Node);

            if (!attributes.Any())
            {
                qualifierBuilder.Qualifies = false;
                return (TBuilder)qualifierBuilder;
            }

            foreach (var attribute in attributes.SelectMany(a => a.Attributes))
            {
                var attributeBuilder = new AttributeQualifierBuilder(attribute, qualifierBuilder.Qualifies);
                builder(attributeBuilder);

                if (attributeBuilder.Qualifies)
                {
                    return (TBuilder)qualifierBuilder;
                }
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        private static SyntaxList<AttributeListSyntax> GetNodeAttributes(SyntaxNode node) =>
            node switch
            {
                TypeDeclarationSyntax declaration => declaration.AttributeLists,
                MethodDeclarationSyntax method => method.AttributeLists,
                null => default,
                _ => default
            };
    }
}
