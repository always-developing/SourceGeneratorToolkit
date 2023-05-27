using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    public static class GeneralModifierQualifierExtensions
    {
        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, GeneralModifier generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            var modifiers = ModifierHelper.GetSyntaxKindFromGeneralModifier(generalModifier);
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, modifiers.ToArray());
        }

        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind generalModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, generalModifier);
        }

        public static TBuilder WithoutModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, GeneralModifier generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            var syntaxModifiers = ModifierHelper.GetSyntaxKindFromGeneralModifier(generalModifier);

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

        public static TBuilder WithoutModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, generalModifier);
        }

        public static TBuilder WithModifiers<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params GeneralModifier[] generalModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            foreach (var generalModifier in generalModifiers)
            {
                var syntaxModifiers = ModifierHelper.GetSyntaxKindFromGeneralModifier(generalModifier);

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

        public static TBuilder WithModifiers<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, generalModifier);
        }

        public static TBuilder WithAnyModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params GeneralModifier[] generamModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            var syntaxModifiers = generamModifier.ToList()
                .SelectMany(m => ModifierHelper.GetSyntaxKindFromGeneralModifier(m));

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, syntaxModifiers.ToArray());
        }

        public static TBuilder WithAnyModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] generalModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyModifier(qualifierBuilder, generalModifier);
        }
    }
}
