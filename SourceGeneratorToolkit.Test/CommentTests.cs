using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class CommentTests
{
    [TestMethod]
    public void Empty_Namespace_With_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns =>
                {
                    ns.AddComment("custom namespace for the test");
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace tstNamespace
{
// custom namespace for the test
}", file);
    }

    [TestMethod]
    public void Empty_Class_Trad_Namespace_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.AddComment("A description about the class");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    class myClass
    {
    // A description about the class
    }
}", file);
    }

    [TestMethod]
    public void Default_Constructor_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cons =>
                        {
                            cons.AddComment("// this is the classes default constructor");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    class myClass
    {
        myClass()
        {
        // this is the classes default constructor
        }
    }
}", file);
    }

    [TestMethod]
    public void Default_Interface_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder => 
                    {
                        builder.AddComment("comment for interface");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    interface IMyInterface
    {
    // comment for interface
    }
}", file);
    }

    [TestMethod]
    public void Interface_Default_Method_Default_Implementation_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder =>
                    {
                        builder
                        .AsPublic()
                        .WithMethod("MyMethod", "void", mth =>
                        {
                            mth
                            .AddComment("returns hardcoded 1")
                            .WithBody("return 1;");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    public interface IMyInterface
    {
        void MyMethod()
        {
            // returns hardcoded 1
            return 1;
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Async_Method_Enforced_Task_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .WithMethod("HelloWorld", "void", meth =>
                        {
                            meth.AsPublic().AsAsync().AddComment("// hello to the world");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    class myClass
    {
        public async Task HelloWorld()
        {
        // hello to the world
        }
    }
}", file);
    }
}
