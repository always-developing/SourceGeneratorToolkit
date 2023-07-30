using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;
using SourceGeneratorToolkit;
using System.Diagnostics;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp;
using System.Threading.Tasks;

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
                    // var cls = result.Node.AsClass();
                    var cls = result.Node.AsAttribute();

                    context.GenerateSource($"{cls.GetNamespace()}1", fileBuilder =>
                    {
                        fileBuilder.WithNamespace($"{cls.GetNamespace()}2", nsBuilder =>
                        {
                            nsBuilder.WithClass($"{cls.GetName()}3", clsBuilder =>
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
                #region attribute example
                node.IsAttribute(att =>
                {
                    att.WithName("Obsolete")
                    .TargetsType(AttributeTargets.Class);
                });
                #endregion

                //#region class example
                //node.IsClass(c => c
                //    .WithName("MyClass")
                //    .IsNotStatic()
                //    .IsNotPrivateProtected()
                //    .IsPublic()
                //    .Implements("ISerializable")
                //    .WithAttribute(a =>
                //    {
                //        a.WithName("Obsolete");
                //    })
                //    .WithMethod(m =>
                //    {
                //        m.WithName("MyMethod")
                //        .IsAsync()
                //        .WithAttribute(a =>
                //        {
                //            a.WithName("Obsolete")
                //            .WithArgument(arg =>
                //            {
                //                arg.WithPosition(1);
                //                //.WithName("error");
                //            });
                //        })
                //        .WithReturnType(typeof(Task));
                //    })
                //);
                //#endregion
            });
        }
    }
}
