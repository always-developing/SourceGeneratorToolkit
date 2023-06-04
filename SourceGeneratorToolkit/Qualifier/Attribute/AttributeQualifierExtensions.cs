using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
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

        public static TParent AppliesTo<TParent>(this IAttributeQualifier<TParent> syntaxBuilder, AttributeAppliesTo appliesTo)
            where TParent : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TParent)syntaxBuilder;
            }

            var attributes = GetNodeAppliesTo(qualifierBuilder.Node);

            var result = qualifierBuilder.Node.SyntaxTree.GetRoot()
                .DescendantNodes()
                .Where(n => n.IsKind(SyntaxKind.ClassDeclaration))
                .Select(n => n as ClassDeclarationSyntax)
                .Where(c =>
                    c.AttributeLists.SelectMany(al => al.Attributes)
                    .Any(a => a.Span.Start == qualifierBuilder.Node.Span.Start));

            //foreach (var attribute in attributes.SelectMany(a => a.Attributes))
            //{
            //    var attributeBuilder = new AttributeQualifierBuilder(attribute, qualifierBuilder.Qualifies);
            //    builder(attributeBuilder);

            //    if (attributeBuilder.Qualifies)
            //    {
            //        return (TBuilder)qualifierBuilder;
            //    }
            //}

            qualifierBuilder.Qualifies = false;
            return (TParent)qualifierBuilder;
        }

        private static AttributeAppliesTo GetNodeAppliesTo(SyntaxNode node) =>
            node switch
            {
                AttributeSyntax attribute => GetAttributeSyntaxAppliesTo(attribute),
                _ => default
            };

        private static AttributeAppliesTo GetAttributeSyntaxAppliesTo(AttributeSyntax attribute)
        {

            return AttributeAppliesTo.Return;
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
