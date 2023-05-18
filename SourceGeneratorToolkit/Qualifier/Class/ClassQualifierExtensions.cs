using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{
    public static class ClassQualifierExtensions
    {
        public static ClassQualifierBuilder WithName(this ClassQualifierBuilder syntaxBuilder, string className)
        {
            if (!syntaxBuilder.Qualifies)
            {
                return syntaxBuilder;
            }

            if (syntaxBuilder.Node is BaseTypeDeclarationSyntax declaration)
            {
                syntaxBuilder.Qualifies = syntaxBuilder.Qualifies && declaration.Identifier.ValueText == className;
            }

            return syntaxBuilder;
        }

        public static ClassQualifierBuilder WithAccessModifier(this ClassQualifierBuilder syntaxBuilder, AccessModifier accessModifier)
        {
            var syntaxModifiers = GetSyntaxKindFromAccessModifier(accessModifier);

            foreach(var modifier in syntaxModifiers)
            {
                syntaxBuilder.WithAccessModifier(modifier);

                //TODO Stuff here
            }

            return syntaxBuilder;
        }

        public static ClassQualifierBuilder WithAccessModifier(this ClassQualifierBuilder syntaxBuilder, SyntaxKind accessModifier)
        {
            if (!syntaxBuilder.Qualifies)
            {
                return syntaxBuilder;
            }

            if (syntaxBuilder.Node.IsKind(SyntaxKind.ClassDeclaration))
            {
                var declaration = syntaxBuilder.Node as BaseTypeDeclarationSyntax;
                var modifiers = declaration.Modifiers;

                syntaxBuilder.Qualifies = syntaxBuilder.Qualifies && modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword));
            }

            return syntaxBuilder;
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
