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
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", builder => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    interface IMyInterface
    {
    }
}", file);
    }

    [TestMethod]
    public void Default_Public_Interface()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public interface IMyInterface
    {
    }
}", file);
    }

    [TestMethod]
    public void Interface_Default_Method()
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
                        .WithMethod("MyMethod", "void");

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public interface IMyInterface
    {
        void MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Public_Method_Return()
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
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPublic();
                        });

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public interface IMyInterface
    {
        public int MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Public_Method_Return_Async()
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
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPublic().AsAsync();
                        });

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public interface IMyInterface
    {
        public Task<int> MyMethod();
    }
}", file);
    }

    [TestMethod]
    public void Interface_Private_Method_Return_Async_Unenforced()
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
                        .WithMethod("MyMethod", "int", mth =>
                        {
                            mth.AsPrivate().AsAsync(false);
                        });

                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public interface IMyInterface
    {
        private int MyMethod();
    }
}", file);
    }
}
