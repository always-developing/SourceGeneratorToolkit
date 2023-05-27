using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SourceGeneratorToolkit
{
    public static class AccessModifierQualifierExtensions
    {
        public static TBuilder IsPublic<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.PublicKeyword);
        }

        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var modifiers = ModifierHelper.GetSyntaxKindFromAccessModifier(accessModifier);
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, modifiers.ToArray());
        }

        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            var syntaxModifiers = ModifierHelper.GetSyntaxKindFromAccessModifier(accessModifier);

            foreach (var modifier in syntaxModifiers)
            {
                ModifierHelper.WithoutModifier(qualifierBuilder, modifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return (TBuilder)qualifierBuilder;
                }
            }

            return (TBuilder)qualifierBuilder;
        }

        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }
        
        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            foreach (var accessModifier in accessModifiers)
            {
                var syntaxModifiers = ModifierHelper.GetSyntaxKindFromAccessModifier(accessModifier);

                foreach (var modifier in syntaxModifiers)
                {
                    ModifierHelper.WithModifier(qualifierBuilder, modifier);

                    if (!qualifierBuilder.Qualifies)
                    {
                        return (TBuilder)qualifierBuilder;
                    }
                }
            }
            return (TBuilder)qualifierBuilder;
        }

        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, accessModifiers);
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            var syntaxModifiers = accessModifiers.ToList()
                .SelectMany(m => ModifierHelper.GetSyntaxKindFromAccessModifier(m));

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, syntaxModifiers.ToArray());
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyModifier(qualifierBuilder, accessModifiers);
        }
    }
}
