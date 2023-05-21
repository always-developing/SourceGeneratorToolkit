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
        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

            foreach (var modifier in syntaxModifiers)
            {
                syntaxBuilder.WithAccessModifier(modifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return (TBuilder)syntaxBuilder;
                }
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)syntaxBuilder;
            }

            if (qualifierBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                var declaration = qualifierBuilder.Node as BaseTypeDeclarationSyntax;
                var modifiers = declaration.Modifiers;

                qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && modifiers.Any(m => m.IsKind(accessModifier));
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithOutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, AccessModifier accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

            foreach (var modifier in syntaxModifiers)
            {
                syntaxBuilder.WithOutAccessModifier(modifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return (TBuilder)syntaxBuilder;
                }
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithOutAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, SyntaxKind accessModifier)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)syntaxBuilder;
            }

            if (qualifierBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                var declaration = qualifierBuilder.Node as BaseTypeDeclarationSyntax;
                var modifiers = declaration.Modifiers;

                qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && !modifiers.Any(m => m.IsKind(accessModifier));
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            foreach (var accessModifier in accessModifiers)
            {
                var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

                foreach (var modifier in syntaxModifiers)
                {
                    WithAccessModifier(syntaxBuilder, modifier);

                    if (!qualifierBuilder.Qualifies)
                    {
                        return (TBuilder)syntaxBuilder;
                    }
                }
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithAccessModifiers<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            foreach (var accessModifier in accessModifiers)
            {
                WithAccessModifier(syntaxBuilder, accessModifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return (TBuilder)syntaxBuilder;
                }
            }

            return (TBuilder)syntaxBuilder;
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params AccessModifier[] accessModifiers)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)syntaxBuilder;
            }

            var syntaxModifiers = accessModifiers.ToList().SelectMany(m => GetSyntaxKindFromAccessModifier(m));

            return WithAnyAccessModifier(syntaxBuilder, syntaxModifiers.ToArray());
        }

        public static TBuilder WithAnyAccessModifier<TBuilder>(this IAccessModifierQualifier<TBuilder> syntaxBuilder, params SyntaxKind[] accessModifiers)
             where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TBuilder)syntaxBuilder;
            }

            var anyQualifies = false;
            foreach (var accessModifier in accessModifiers)

                if (qualifierBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
                {
                    var declaration = qualifierBuilder.Node as BaseTypeDeclarationSyntax;
                    var modifiers = declaration.Modifiers;

                    if (modifiers.Any(m => m.IsKind(accessModifier)))
                    {
                        anyQualifies = true;
                    }
                }

            qualifierBuilder.Qualifies = anyQualifies;

            return (TBuilder)syntaxBuilder;
        }

        private static List<SyntaxKind> GetSyntaxKindFromAccessModifier(AccessModifier accessModifier) => accessModifier switch
        {
            AccessModifier.Public => new List<SyntaxKind> { SyntaxKind.PublicKeyword },
            AccessModifier.Private => new List<SyntaxKind> { SyntaxKind.PrivateKeyword },
            AccessModifier.Protected => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword },
            AccessModifier.Internal => new List<SyntaxKind> { SyntaxKind.InternalKeyword },
            AccessModifier.ProtectedInternal => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword },
            AccessModifier.PrivateProtected => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword, SyntaxKind.PrivateKeyword }
        };
    }
}
