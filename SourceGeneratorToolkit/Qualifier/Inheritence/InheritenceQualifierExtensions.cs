using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class InheritenceQualifierExtensions
    {
        public static TBuilder InheritsFrom<TBuilder>(this IHasInheritenceQualifier<TBuilder> syntaxBuilder, string baseClassName)
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
