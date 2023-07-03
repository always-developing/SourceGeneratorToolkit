# Source Generator Toolkit

The `Source Generator Toolkit` provides functionality to easily generate c# code/files using a _fluent builder pattern_ - while initially designed to be used in conjunction with the .NET Roslyn Source Generator process, the functionalty can be leveraged outside of process to generate c# sour code.


# Generating Code - outside of the Roslyn Source Generator process

The static `SourceGenerator` class is the starting point for building up the source code. This process will generate a **formatted string representation of the c# code**:

``` csharp
var strCode = SourceGenerator.GenerateSource(gen =>
{
    gen.WithFile("file1", file =>
    {
        file.WithNamespace("SampleNamespace", ns =>
        {
            ns.WithClass("SampleClass", cls => { });
        });
    });
});
```

The string output of the above being (the value of `strCode`):

``` csharp
namespace SampleNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("SourceGeneratorToolkit", "0.0.0.1")]
    class SampleClass
    {
    }
}
```

# Generating Code - Roslyn Source Generator process (without ISyntaxReceiver)

When used in conjunction with a Source Generator, the `GenerateSource` extension method on the `GeneratorExecutionContext` class can be leveraged. 

The below example shows how to generate source code `without any information from a SyntaxReceiver` - see further down on how the `Source Generator Toolkit` can be used to generate code in conjunction with a `ISyntaxReceiver` implementation.

``` csharp
public class SampleGenerator : ISourceGenerator
{
    public void Execute(GeneratorExecutionContext context)
    {
        context.GenerateSource("file1", fileBuilder =>
        {
            fileBuilder.WithNamespace("SampleNamespace", nsBuilder =>
            {
                ns.WithClass("SampleClass", cls => { });
            });
        });
    }

    public void Initialize(GeneratorInitializationContext context)
    {
        // no ISyntaxReceiver implementation registered here
    }
}
```

In the case of a Source Generator, an actual file named `file1.cs` will be output as part of the generation process.

The output content of the file will be the same as in the previous example:

``` csharp
namespace SampleNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("SourceGeneratorToolkit", "0.0.0.1")]
    class SampleClass
    {
    }
}
```

---

# Generating Code - Configuration

There is optional configuration which can be specified when generating the code using either of the above two methods (when calling the `GenerateSource` method). If no configuration is specificied, the default configuration is used.

|Configuration Name|Description|Default Value|
|---|---|---|
|OutputGeneratedCodeAttribute|Flag to indicate if the `System.CodeDom.Compiler.GeneratedCode` attribute should be output with generated code. This attribute is used as an indicator to various tools that the code was auto generated|true|
|OutputDebuggerStepThroughAttribute|Flag to indicate if the `System.Diagnostics.DebuggerStepThrough` attribute should be output with generated code. When set to true, this attribute allows stepping into the generated code when debugging|false|

---

# Generating Code - more examples

In the [unit test](https://github.com/always-developing/SourceGeneratorToolkit/tree/main/tests/SourceGeneratorToolkit.Test) project of the source code, there are numerous examples of all the possible c# language components the library is capable of generating. 

---

# Code Qualification - Roslyn Source Generator process (with ISyntaxReceiver implementation)

When using the .NET Roslyn Source Generator process, the actual _generation_ of the source is only one step of the process - the other step is determining _if the source should be generated in the first place_. This _qualification check_ is done in the `OnVisitSyntaxNode` method of the `ISyntaxReceiver` implementation.

The `OnVisitSyntaxNode` method takes a `SyntaxNode` as an argument (this is part of the normal Roslyn Source Generator process) - the `Source Generator Toolkit` provides an extension method (`NodeQualifiesWhen`) which accepts a _qualificaiton builder_ which is used to determine if the SyntaxNode qualifies to have source code generated.

The _fluent builder_ pattern is again used to build up the qualification check for for the syntax. See the below example:

``` csharp
class SampleClassSyntaxReceiver : ISyntaxReceiver
{
    public List<SyntaxReceiverResult> Results { get; set; } = new List<SyntaxReceiverResult>();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        syntaxNode.NodeQualifiesWhen(Results, node =>
        {
            node.IsClass(c => c
                .WithName("SampleClass")
                .IsNotStatic()
                .IsPublic()
                .Implements("ISerializable")
            );
        });
    }
}
```

If the source generator (leveraging the `Source Generator Toolkit` methods), determines the node is a _class named `SampleClass` which is not static, public and implements `ISerializable`_, then the specific `SyntaxNode` qualifies, and the _Results_ list will be populated and passed to the _Execute_ method of the generator.