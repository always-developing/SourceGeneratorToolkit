using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit.Qualifier.Modifier
{
    public static class GeneralAccessQualifierExtensions
    {
        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithoutModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithoutModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithModifiers<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAccessModifiers(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAnyModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyAccessModifier(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAnyModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyAccessModifier(qualifierBuilder, accessModifiers);
        }
    }
}
