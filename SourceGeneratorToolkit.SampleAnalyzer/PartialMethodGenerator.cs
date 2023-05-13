using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using SourceGeneratorToolkit;
using System.Diagnostics;

namespace SourceGeneratorToolkit.SampleAnalyzer
{
    [Generator]
    public class PartialMethodGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver == null)
            {
                return;
            }

            PartialClassSyntaxReceiver syntaxReceiver = (PartialClassSyntaxReceiver)context.SyntaxReceiver;
            Debug.Assert(syntaxReceiver != null);

            if (syntaxReceiver != null && syntaxReceiver.Result != null)
            {
                var result = syntaxReceiver?.Result;

                context.GenerateSource($"{result.Name}1", fileBuilder =>
                {
                    fileBuilder.WithNamespace($"{result.Namespace}2", nsBuilder =>
                    {
                        nsBuilder.WithClass($"{result.Name}3", clsBuilder =>
                        {
                            clsBuilder.AsPublic();

                            clsBuilder.WithMethod("Hello", "void", mthBuilder =>
                            {
                                mthBuilder.AsPublic()
                                .WithBody(@"Console.WriteLine($""Generator says: Hello"");");
                            });
                        });
                    });
                });
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // Register a factory that can create our custom syntax receiver
            context.RegisterForSyntaxNotifications(() => new PartialClassSyntaxReceiver());
        }
    }

    class PartialClassSyntaxReceiver : ISyntaxReceiver
    {
        public SyntaxReceiverResult Result { get; private set; }

        public ClassDeclarationSyntax ClassToAugment { get; private set; }

        public int IntValue{ get; private set; }

        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            if(syntaxNode.NodeQualifiesWhen(node =>
            {
                node.IsClass();
            }))
            {
                Result = syntaxNode.BuildResult();
            }

            if(Result != null) 
            {
                ClassToAugment = syntaxNode as ClassDeclarationSyntax;
            }

            //if (syntaxNode is ClassDeclarationSyntax cds)
            //{
            //    Result = new SyntaxReceiverResult
            //    {
            //        Name = "MyClass",
            //        Namespace = "MyNs"
            //    };
            //}


            //// Business logic to decide what we're interested in goes here
            //if (syntaxNode is ClassDeclarationSyntax cds &&
            //    cds.Identifier.ValueText == "UserClass")
            //{
            //    //ClassToAugment = cds;
            //}
        }
    }
}
