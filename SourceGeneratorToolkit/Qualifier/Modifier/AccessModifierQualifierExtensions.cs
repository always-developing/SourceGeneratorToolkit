using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for access modifiers
    /// </summary>
    public static class AccessModifierQualifierExtensions
    {
        /// <summary>
        /// Checks that the syntax has the public modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsPublic<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if(!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.PublicKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the public modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotPublic<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.PublicKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the private modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsPrivate<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.PrivateKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the private modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotPrivate<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.PrivateKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the protected modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsProtected<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.ProtectedKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the private modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotProtected<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.ProtectedKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the internal modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsInternal<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.InternalKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have the private modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotInternal<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.InternalKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the file modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsFile<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, SyntaxKind.FileKeyword);
        }

        /// <summary>
        /// Checks that the syntax does not have private modifier
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotFile<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
           where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, SyntaxKind.FileKeyword);
        }

        /// <summary>
        /// Checks that the syntax has the protected internal modifiers
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsProtectedInternal<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
          where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, new[] { SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword });
        }

        /// <summary>
        /// Checks that the syntax does not have the protected internal modifiers
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotProtectedInternal<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
          where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            // Checking if all the modifiers are applied
            qualifierBuilder = syntaxBuilder.WithAccessModifiers(SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword);

            // Then reverse the qualifies flag
            qualifierBuilder.Qualifies = !qualifierBuilder.Qualifies;

            return (TBuilder)qualifierBuilder;
        }

        /// <summary>
        /// Checks that the syntax has the private protected modifiers
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsPrivateProtected<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
          where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, new[] { SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword });
        }

        /// <summary>
        /// Checks that the syntax does not have the private protected modifiers
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder IsNotPrivateProtected<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder)
          where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            // Checking if all the modifiers are applied
            qualifierBuilder = syntaxBuilder.WithAccessModifiers(SyntaxKind.PrivateKeyword, SyntaxKind.ProtectedKeyword);

            // Then reverse the qualifies flag
            qualifierBuilder.Qualifies = !qualifierBuilder.Qualifies;

            return (TBuilder)qualifierBuilder;
        }

        /// <summary>
        /// Checks that the syntax has the access modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifier">The access modifier</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            var modifiers = ModifierHelper.GetSyntaxKindFromAccessModifier(accessModifier);
            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, modifiers.ToArray());
        }

        /// <summary>
        /// Checks that the syntax has the access modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifier">The access modifier (as a SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifier(qualifierBuilder, accessModifier);
        }

        /// <summary>
        /// Checks that the syntax does not have the access modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifier">The access modifier</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

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

        /// <summary>
        /// Checks that the syntax does not have the access modifier specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifier">The access modifier (as a SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithoutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithoutModifier(qualifierBuilder, accessModifier);
        }

        /// <summary>
        /// Checks that the syntax has all the access modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifiers">The access modifiers</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

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

        /// <summary>
        /// Checks that the syntax has all the access modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifiers">The access modifiers (as SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithModifiers(qualifierBuilder, accessModifiers);
        }

        /// <summary>
        /// Checks that the syntax has any of the access modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifiers">The access modifiers</param>
        /// <returns>The qualifier builder</returns>
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

        /// <summary>
        /// Checks that the syntax has any of the access modifiers specified
        /// </summary>
        /// <typeparam name="TBuilder">The qualifier builder type</typeparam>
        /// <param name="syntaxBuilder">The qualifier builder</param>
        /// <param name="accessModifiers">The access modifiers (as SyntaxKind)</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)qualifierBuilder;
            }

            return (TBuilder)ModifierHelper.WithAnyModifier(qualifierBuilder, accessModifiers);
        }
    }
}
