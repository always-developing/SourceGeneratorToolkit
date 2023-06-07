using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SourceGeneratorToolkit
{
    /// <summary>
    /// Extension methods for attribute related qualifier
    /// </summary>
    public static class AttributeQualifierExtensions
    {
        /// <summary>
        /// Checks if the node has an attribute with the specified criteria
        /// </summary>
        /// <typeparam name="TBuilder">The parent type</typeparam>
        /// <param name="syntaxBuilder">The qualifier</param>
        /// <param name="builder">The qualifier builder</param>
        /// <returns>The qualifier builder</returns>
        public static TBuilder WithAttribute<TBuilder>(this IHasAttributeQualifier<TBuilder> syntaxBuilder, Action<AttributeQualifierBuilder> builder)
            where TBuilder : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            var attributes = GetNodeAttributes(qualifierBuilder.Node);

            if (!attributes.Any())
            {
                qualifierBuilder.Qualifies = false;
                return (TBuilder)qualifierBuilder;
            }

            foreach (var attribute in attributes.SelectMany(a => a.Attributes))
            {
                var attributeBuilder = new AttributeQualifierBuilder(attribute, qualifierBuilder.Qualifies);
                builder(attributeBuilder);

                if (attributeBuilder.Qualifies)
                {
                    return (TBuilder)qualifierBuilder;
                }
            }

            qualifierBuilder.Qualifies = false;
            return (TBuilder)qualifierBuilder;
        }

        public static TParent TargetsType<TParent>(this IAttributeQualifier<TParent> syntaxBuilder, AttributeTargets target)
            where TParent : QualfierBuilder
        {
            var qualifierBuilder = syntaxBuilder as QualfierBuilder;

            if (!qualifierBuilder.Qualifies)
            {
                return (TParent)syntaxBuilder;
            }

            var targetDataList = GetTargetSyntaxData(target);

            if(!targetDataList.Any())
            {
                qualifierBuilder.Qualifies = false;
                return (TParent)syntaxBuilder;
            }

            var qualifies = false;
            foreach (var (Kind, TargetType) in targetDataList)
            {
                qualifies = GetQualifyingTargetNodes(TargetType, qualifierBuilder, Kind);

                if(!qualifies) 
                {
                    break;
                }
            }
            qualifierBuilder.Qualifies = qualifies;

            return (TParent)qualifierBuilder;
        }

        private static List<(SyntaxKind Kind, Type TargetType)> GetTargetSyntaxData(AttributeTargets target)
        {
            var targetData = new List<(SyntaxKind, Type)>();

            foreach(var targetType in Enum.GetValues(typeof(AttributeTargets)))
            {
                if((target & AttributeTargets.Event) != 0)
                {
                    targetData.Add((SyntaxKind.EventDeclaration, typeof(EventDeclarationSyntax)));
                }
                if ((target & AttributeTargets.ReturnValue) != 0)
                {
                    targetData.Add((SyntaxKind.ReturnKeyword, typeof(ReturnStatementSyntax)));
                }
                if ((target & AttributeTargets.Class) != 0)
                {
                    targetData.Add((SyntaxKind.ClassDeclaration, typeof(MemberDeclarationSyntax)));
                }
                if ((target & AttributeTargets.Method) != 0)
                {
                    targetData.Add((SyntaxKind.MethodDeclaration, typeof(MethodDeclarationSyntax)));
                }
                if ((target & AttributeTargets.Parameter) != 0)
                {
                    targetData.Add((SyntaxKind.Parameter, typeof(ParameterSyntax)));
                }
                if ((target & AttributeTargets.GenericParameter) != 0)
                {
                    targetData.Add((SyntaxKind.GenericName, default));
                }
                if ((target & AttributeTargets.Assembly) != 0)
                {
                    targetData.Add((SyntaxKind.AssemblyKeyword, default));
                }
                if ((target & AttributeTargets.Module) != 0)
                {
                    targetData.Add((SyntaxKind.ModuleKeyword, default));
                }
                if ((target & AttributeTargets.Field) != 0)
                {
                    targetData.Add((SyntaxKind.FieldDeclaration, typeof(FieldDeclarationSyntax)));
                }
                if ((target & AttributeTargets.Property) != 0)
                {
                    targetData.Add((SyntaxKind.PropertyDeclaration, typeof(PropertyDeclarationSyntax)));
                }
            }

            return targetData;
        }


        private static bool GetQualifyingTargetNodes(Type targetType, QualfierBuilder qualifierBuilder, SyntaxKind syntaxKind)
        {
            var result = qualifierBuilder.Node.SyntaxTree.GetRoot()
                .DescendantNodes()
                .Where(n => n.IsKind(syntaxKind));

            if(targetType == typeof(MemberDeclarationSyntax))
            {
                return result
                    .Select(n => n as MemberDeclarationSyntax)
                    .Where(c =>
                    c.AttributeLists.SelectMany(al => al.Attributes)
                    .Any(a => a.Span.Start == qualifierBuilder.Node.Span.Start))
                    .Any();
            }

            return false;
        }


        private static SyntaxList<AttributeListSyntax> GetNodeAttributes(SyntaxNode node) =>
            node switch
            {
                TypeDeclarationSyntax declaration => declaration.AttributeLists,
                MethodDeclarationSyntax method => method.AttributeLists,
                null => default,
                _ => default
            };
    }
}
