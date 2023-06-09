using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for interface related qualifier
    /// </summary>
    public static class IImplementsQualifierExtensions
    {
        /// <summary>
        /// Checks if the node implements the interface name specified
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="interfacename">The interface name</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder Implements<TBuilder>(this IHasInheritenceQualifier<TBuilder> syntaxBuilder, string interfacename)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (qualifierBuilder.Node is ClassDeclarationSyntax cls)
            {
                // check there are any
                if (cls.BaseList == null || !cls.BaseList.Types.Any())
                {
                    qualifierBuilder.Qualifies = false;
                    return (TBuilder)qualifierBuilder;
                }

                // could also be interface
                var potentialInheritsFrom = cls.BaseList.Types[0];

                if (interfacename.Equals(potentialInheritsFrom.ToString(), StringComparison.InvariantCultureIgnoreCase))
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
