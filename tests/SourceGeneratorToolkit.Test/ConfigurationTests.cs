using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ConfigurationTests
{
    [TestMethod]
    public void Class_With_GeneratedCodeAttribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_WithOut_GeneratedCodeAttribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }, new BuilderConfiguration { OutputGeneratedCodeAttribute = false });

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_With_GeneratedCode_And_StepThrough_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }, new BuilderConfiguration { OutputDebuggerStepThroughAttribute = true });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [System.Diagnostics.DebuggerStepThrough]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_With_Only_StepThrough_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }, new BuilderConfiguration
        {
            OutputDebuggerStepThroughAttribute = true,
            OutputGeneratedCodeAttribute = false
        }) ;

        Assert.AreEqual(@"namespace testns
{
    [System.Diagnostics.DebuggerStepThrough]
    class myClass
    {
    }
}", file);
    }
}
