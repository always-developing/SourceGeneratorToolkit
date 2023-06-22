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

            var modifiers = GetNodeModifiers(qualifierBuilder.Node);
            qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && modifiers.Any(m => m.IsKind(accessModifier));

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithoutModifier(QualfierBuilder qualifierBuilder, SyntaxKind accessModifier)
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
            }

            var modifiers = GetNodeModifiers(qualifierBuilder.Node);
            qualifierBuilder.Qualifies = qualifierBuilder.Qualifies && !modifiers.Any(m => m.IsKind(accessModifier));

            return qualifierBuilder;
        }

        internal static QualfierBuilder WithModifiers(QualfierBuilder qualifierBuilder, SyntaxKind[] accessModifiers)
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

        internal static QualfierBuilder WithAnyModifier(QualfierBuilder qualifierBuilder, SyntaxKind[] accessModifiers)
        {
            if (!qualifierBuilder.Qualifies)
            {
                return qualifierBuilder;
            }

            var anyQualifies = false;
            foreach (var accessModifier in accessModifiers)
            {
                var modifiers = GetNodeModifiers(qualifierBuilder.Node);

                if (modifiers.Any(m => m.IsKind(accessModifier)))
                {
                    anyQualifies = true;
                }
            }

            qualifierBuilder.Qualifies = anyQualifies;

            return qualifierBuilder;
        }

        internal static List<SyntaxKind> GetSyntaxKindFromAccessModifier(AccessModifier accessModifier) => accessModifier switch
        {
            AccessModifier.Public => new List<SyntaxKind> { SyntaxKind.PublicKeyword },
            AccessModifier.Private => new List<SyntaxKind> { SyntaxKind.PrivateKeyword },
            AccessModifier.Protected => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword },
            AccessModifier.Internal => new List<SyntaxKind> { SyntaxKind.InternalKeyword },
            AccessModifier.ProtectedInternal => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword, SyntaxKind.InternalKeyword },
            AccessModifier.PrivateProtected => new List<SyntaxKind> { SyntaxKind.ProtectedKeyword, SyntaxKind.PrivateKeyword },
            AccessModifier.File => new List<SyntaxKind> { SyntaxKind.FileKeyword },
            _ => new List<SyntaxKind> {}
        };

        internal static List<SyntaxKind> GetSyntaxKindFromGeneralModifier(GeneralModifier generalModifier) => generalModifier switch
        {
            GeneralModifier.Abstract => new List<SyntaxKind> { SyntaxKind.AbstractKeyword },
            GeneralModifier.Async => new List<SyntaxKind> { SyntaxKind.AsyncKeyword },
            GeneralModifier.Override => new List<SyntaxKind> { SyntaxKind.OverrideKeyword },
            GeneralModifier.Partial => new List<SyntaxKind> { SyntaxKind.PartialKeyword },
            GeneralModifier.Readonly => new List<SyntaxKind> { SyntaxKind.ReadOnlyKeyword },
            GeneralModifier.Required => new List<SyntaxKind> { SyntaxKind.RequiredKeyword },
            GeneralModifier.Sealed => new List<SyntaxKind> { SyntaxKind.SealedKeyword },
            GeneralModifier.Static => new List<SyntaxKind> { SyntaxKind.StaticKeyword },
            GeneralModifier.Unsafe => new List<SyntaxKind> { SyntaxKind.UnsafeKeyword },
            GeneralModifier.Virtual => new List<SyntaxKind> { SyntaxKind.VirtualKeyword },
            _ => new List<SyntaxKind> { }
        };

        private static SyntaxTokenList GetNodeModifiers(SyntaxNode node) =>
            node switch
            {
                BaseTypeDeclarationSyntax declaration => declaration.Modifiers,
                MemberDeclarationSyntax memberDeclatation => memberDeclatation.Modifiers,
                null => default,
                _ => default
            };

    }
}
