using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using SourceGeneratorToolkit;
using System.Diagnostics;
using System.Linq;

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

            if (syntaxReceiver != null && syntaxReceiver.Results != null && syntaxReceiver.Results.Any())
            {
                foreach (var result in syntaxReceiver.Results)
                {
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
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // Register a factory that can create our custom syntax receiver
            context.RegisterForSyntaxNotifications(() => new PartialClassSyntaxReceiver());
        }
    }

    class PartialClassSyntaxReceiver : ISyntaxReceiver
    {
        public List<SyntaxReceiverResult> Results { get; set; } = new List<SyntaxReceiverResult>();
        
        public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            syntaxNode.NodeQualifiesWhen(Results, node =>
            {
                node.IsClass(c => c
                    .WithName("MyClass")
                    .WithAccessModifier("")
                );
            });
        }
    }
}
