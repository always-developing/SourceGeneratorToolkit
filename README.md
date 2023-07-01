# Source Generator Toolkit

## Generating Code

While the SourceGenerator Toolkit was designed to be used as part of the .NET Roslyn Source Generator process, it can be leveraged outside of that to generate c# files and source code. In both cases, a _fluent builder_ pattern is used to build up the build up thew source code step-by-step.

### Outside of Roslyn Source Generator 

The static `SourceGenerator` class is the starting point for building up the source code. This process will generate a **string representation of the c# code**:

``` csharp
var file = SourceGenerator.GenerateSource(gen =>
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

The string output of the above being:

``` csharp
namespace SampleNamespace
{
    [System.CodeDom.Compiler.GeneratedCode("SourceGeneratorToolkit", "0.0.0.1")]
    class SampleClass
    {
    }
}
```

### With Roslyn Source Generator 

When usedin conjunction with a Source Generator, the `GenerateSource` extension method on the `GeneratorExecutionContext` class can be leveraged:

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

### Configuration

There is optional configuration which can be specified when generating the code using either of the above two methods. If no configuration is specificied, the default configuration is used.

|Configuration Name|Description|Default Value|
|---|---|---|
|OutputGeneratedCodeAttribute|Flag to indicate if the `System.CodeDom.Compiler.GeneratedCode` attribute should be output with generated code. This attribute is used as an indicator to various tools that the code was auto generated|true|
|OutputDebuggerStepThroughAttribute|Flag to indicate if the `System.Diagnostics.DebuggerStepThrough` attribute should be output with generated code. When set to true, this attribute allows stepping into the generated code when debugging|false|

---

### More examples

In the [unit test](https://github.com/always-developing/SourceGeneratorToolkit/tree/main/tests/SourceGeneratorToolkit.Test) project of the source code, there are numerous examples of all the possible c# language components the library is capable of generating. 

---

## Qualifiying Code with Source Generators

When using the .NET Roslyn Source Generator process, the actual _generation_ of the source is only one step of the process - the other is determining _if the source should be generated in the first place_. This _qualification check_ is done in the `OnVisitSyntaxNode` method of the `ISyntaxReceiver` implementation.

The `OnVisitSyntaxNode` method takes a `SyntaxNode` as an argument (this is part of the normal Roslyn Source Generator process) - the `Source Generator Toolkit` provides an extension method (`NodeQualifiesWhen`) which accepts a _qualificaiton builder_ which is used to determine if the SyntaxNode qualifies to have source code generated from it.

More to come