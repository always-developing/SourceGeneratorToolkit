using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Text;

namespace SourceGeneratorToolkit.SampleAnalyzer
{
    [Generator]
    public class BasicHelloGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            context.GenerateSource("file1", fileBuilder =>
            {
                fileBuilder.WithNamespace("ns", nsBuilder =>
                {
                    nsBuilder.WithClass("GenClass", clsBuilder =>
                    {
                        clsBuilder.AsStatic().AsPublic();

                        clsBuilder.WithMethod("Hello", "void", mthBuilder =>
                        {
                            mthBuilder.AsStatic().AsPublic()
                            .WithBody(@"Console.WriteLine($""Generator says: Hello!!!"");");
                        });
                    });
                });
            }, configuration =>
            {
                configuration.OutputGeneratedCodeAttribute = false;
                configuration.OutputDebuggerStepThroughAttribute = true;
            });
        }

        public void Initialize(GeneratorInitializationContext context)
        {
        }
    }
}
