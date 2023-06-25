using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for method related qualfiiers
    /// </summary>
    public static class MethodQualifierExtensions
    {
        /// <summary>
        /// Checks if the node has a method with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithMethod<TBuilder>(this IMethodQualifier<TBuilder> syntaxBuilder, Action<MethodQualifierBuilder> builder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var members = GetNodeMembers(qualifierBuilder.Node);

            if (!members.Any())
            {
                qualifierBuilder.Qualifies = false;
                return (TBuilder)qualifierBuilder;
            }

            foreach (var member in members)
            {
                var methodBuilder = new MethodQualifierBuilder(member, qualifierBuilder.Qualifies);
                builder(methodBuilder);

                if (methodBuilder.Qualifies)
                {
                    return (TBuilder)qualifierBuilder;
                }
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        private static SyntaxList<MemberDeclarationSyntax> GetNodeMembers(SyntaxNode node) =>
            node switch
            {
                TypeDeclarationSyntax declaration => declaration.Members,
                null => default,
                _ => default
            };
    }
}
