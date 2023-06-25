using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for general modifiers
    /// </summary>
    public static class GeneralModifierQualifierExtensions
    {
        /// <summary>
        /// Checks that the syntax has the abstract modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsAbstract<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.AbstractKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the abstract modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotAbstract<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.AbstractKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the async modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsAsync<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.AsyncKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the async modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotAsync<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.AsyncKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the override modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsOverride<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.OverrideKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the override modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotOverride<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.OverrideKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the partial modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsPartial<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.PartialKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the partial modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotPartial<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.PartialKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the readonly modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsReadOnly<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.ReadOnlyKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the readonly modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotReadOnly<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.ReadOnlyKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the required modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsRequired<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.RequiredKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the required modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotRequired<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.RequiredKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the sealed modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsSealed<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.SealedKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the sealed modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotSealed<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.SealedKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the static modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsStatic<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.StaticKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the static modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotStatic<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.StaticKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the unsafe modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsUnsafe<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.UnsafeKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the unsafe modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotUnsafe<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.UnsafeKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the virtual modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsVirtual<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.VirtualKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the virtual modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotVirtual<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.VirtualKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifier</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, GeneralModifier generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            var modifiers = ModifierHelper.GetSyntaxKindFromGeneralModifier(generalModifier);
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, modifiers.ToArray());
        }

        /// <summary>
        /// Checks that the syntax has the modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifier (as a SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind generalModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, generalModifier);
        }

        /// <summary>
        /// Checks that the syntax does not have the modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifier</param>
        /// <returns>The qualifier builder</returns>
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

        /// <summary>
        /// Checks that the syntax does not have the modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifier (as a SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithoutModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, generalModifier);
        }

        /// <summary>
        /// Checks that the syntax has all the modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifiers">The modifiers</param>
        /// <returns>The qualifier builder</returns>
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

        /// <summary>
        /// Checks that the syntax has all the modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifiers (as SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithModifiers<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, generalModifier);
        }

        /// <summary>
        /// Checks that the syntax has any of the modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifiers</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAnyModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params GeneralModifier[] generalModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            var syntaxModifiers = generalModifier.ToList()
                .SelectMany(m => ModifierHelper.GetSyntaxKindFromGeneralModifier(m));

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, syntaxModifiers.ToArray());
        }

        /// <summary>
        /// Checks that the syntax has any of the modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="generalModifier">The modifiers (as SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAnyModifier<TBuilder>(this IGeneralModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] generalModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;
            return (TBuilder)ModifierHelper.WithAnyModifier(qualifierBuilder, generalModifier);
        }
    }
}
