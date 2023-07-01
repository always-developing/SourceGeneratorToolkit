using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class InterfaceTests
{
    [TestMethod]
    public void Default_Interface()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder => { });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    interface IMyInterface
    {
    }
}", file);
    }

    [TestMethod]
    public void Default_Public_Interface()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder => 
                    {
                        builder.AsPublic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
    }
}", file);
    }

    [TestMethod]
    public void Interface_Default_Method()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder =>
                    {
                        builder
                        .AsPublic()
                        .WithMethod("MyMethod", "void");

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
        void MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Public_Method_Return()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder =>
                    {
                        builder
                        .AsPublic()
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPublic();
                        });

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
        public int MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Public_Method_Return_Async()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder =>
                    {
                        builder
                        .AsPublic()
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPublic().AsAsync();
                        });

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
        public Task<int> MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Private_Method_Return_Async_Unenforced()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder =>
                    {
                        builder
                        .AsPublic()
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPrivate().AsAsync(false);
                        });

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
        private int MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Default_Method_Default_Implementation()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
                            mth.WithBody("return 1;");
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public interface IMyInterface
    {
        void MyMethod()
        {
            return 1;
        }
    }
}", file);
    }
}
