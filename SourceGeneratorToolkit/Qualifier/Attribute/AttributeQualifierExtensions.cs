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

        public static TParent TargetsType<TParent>(this IAttributeQualifier<TParent> syntaxBuilder, AttributeTarget target)
            where TParent : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TParent)syntaxBuilder;
            }

            var targetData = GetTargetSyntaxData(target);
            qualifierBuilder.Qualifies = GetQualifyingTargetNodes(targetData.TargetType, qualifierBuilder, targetData.Kind); 

            return (TParent)qualifierBuilder;
        }

        private static (SyntaxKind Kind, Type TargetType) GetTargetSyntaxData(AttributeTarget target) => target switch
        {
            AttributeTarget.Event => (SyntaxKind.EventDeclaration, typeof(EventDeclarationSyntax)),
            AttributeTarget.Return => (SyntaxKind.ReturnKeyword, typeof(ReturnStatementSyntax)),
            AttributeTarget.Type => (SyntaxKind.ClassDeclaration, typeof(MemberDeclarationSyntax)),
            AttributeTarget.Method => (SyntaxKind.MethodDeclaration, typeof(MethodDeclarationSyntax)),
            AttributeTarget.Param => (SyntaxKind.Parameter, typeof(ParameterSyntax)),
            AttributeTarget.Assembly => (SyntaxKind.AssemblyKeyword, default),
            AttributeTarget.Module => (SyntaxKind.ModuleKeyword, default),
            AttributeTarget.Field => (SyntaxKind.FieldDeclaration, typeof(FieldDeclarationSyntax)),
            AttributeTarget.Property => (SyntaxKind.PropertyDeclaration, typeof(PropertyDeclarationSyntax)),
            _ => (default, default)
        };


        private static bool GetQualifyingTargetNodes(Type targetType, QualfierBuilder qualifierBuilder, SyntaxKind syntaxKind)
        {
            var result = qualifierBuilder.Node.SyntaxTree.GetRoot()
                .DescendantNodes()
                .Where(n => n.IsKind(syntaxKind));

            if(targetType == typeof(MemberDeclarationSyntax))
            {
                return result
                    .Select(n => n as MemberDeclarationSyntax)
                    .Where(c =>
                    c.AttributeLists.SelectMany(al => al.Attributes)
                    .Any(a => a.Span.Start == qualifierBuilder.Node.Span.Start))
                    .Any();
            }

            return false;
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
