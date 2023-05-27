using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SourceGeneratorToolkit
{
    internal static class ModifierHelper
    {
        internal static QualfierBuilder WithModifier(QualfierBuilder qualifierBuilder, SyntaxKind accessModifier)
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
            }

            if (qualifierBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                var declaration = qualifierBuilder.Node as BaseTypeDeclarationSyntax;
                var modifiers = declaration.Modifiers;

                qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && modifiers.Any(m => m.IsKind(accessModifier));
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithModifier(QualfierBuilder qualifierBuilder, AccessModifier accessModifier)
        {
            var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

            foreach (var modifier in syntaxModifiers)
            {
                WithModifier(qualifierBuilder, modifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return qualifierBuilder;
                }
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithoutModifier(QualfierBuilder qualifierBuilder, AccessModifier accessModifier)
        {
            var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

            foreach (var modifier in syntaxModifiers)
            {
                WithoutModifier(qualifierBuilder,modifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return qualifierBuilder;
                }
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithoutModifier(QualfierBuilder qualifierBuilder, SyntaxKind accessModifier) 
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
            }

            if (qualifierBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                var declaration = qualifierBuilder.Node as BaseTypeDeclarationSyntax;
                var modifiers = declaration.Modifiers;

                qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && !modifiers.Any(m => m.IsKind(accessModifier));
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithModifiers(QualfierBuilder qualifierBuilder, AccessModifier[] accessModifiers) 
        {
            foreach (var accessModifier in accessModifiers)
            {
                var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

                foreach (var modifier in syntaxModifiers)
                {
                    //ModifierHelper.WithAccessModifier(syntaxBuilder, modifier);

                    if (!qualifierBuilder.Qualifies)
                    {
                        return qualifierBuilder;
                    }
                }
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithAccessModifiers(QualfierBuilder qualifierBuilder, SyntaxKind[] accessModifiers)
        {
            foreach (var accessModifier in accessModifiers)
            {
                WithModifier(qualifierBuilder, accessModifier);

                if (!qualifierBuilder.Qualifies)
                {
                    return qualifierBuilder;
                }
            }

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithAnyAccessModifier(QualfierBuilder qualifierBuilder, AccessModifier[] accessModifiers) 
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
            }

            var syntaxModifiers = accessModifiers.ToList().SelectMany(m => GetSyntaxKindFromAccessModifier(m));

            return WithAccessModifiers(qualifierBuilder, syntaxModifiers.ToArray());
        }

        internal static QualfierBuilder WithAnyAccessModifier(QualfierBuilder qualifierBuilder, SyntaxKind[] accessModifiers) 
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
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

            return qualifierBuilder;
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
