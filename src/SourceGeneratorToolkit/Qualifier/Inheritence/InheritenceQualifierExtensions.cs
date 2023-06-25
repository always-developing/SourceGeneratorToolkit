using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for inheritence related qualifier
    /// </summary>
    public static class InheritenceQualifierExtensions
    {
        /// <summary>
        /// Checks if the node has inherits from the base class name specified
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="baseClassName">The base class name</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder Inherits<TBuilder>(this IHasInheritenceQualifier<TBuilder> syntaxBuilder, string baseClassName)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if(qualifierBuilder.Node is ClassDeclarationSyntax cls)
            {
                // check there are any
                if(cls.BaseList == null || !cls.BaseList.Types.Any())
                {
                    qualifierBuilder.Qualifies = false;
                    return (TBuilder)qualifierBuilder;
                }

                // could also be interface
                var potentialInheritsFrom = cls.BaseList.Types[0];

                if(baseClassName.Equals(potentialInheritsFrom.ToString(), StringComparison.InvariantCultureIgnoreCase))
                {
                    qualifierBuilder.Qualifies = true;
                    return (TBuilder)qualifierBuilder;
                }
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }
    }
}
