using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class MethodTests
{
    [TestMethod]
    public void Empty_Method_No_Modifier()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    class myClass
    {
        void HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Method_Public_Modifier()
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
                            meth.AsPublic();
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
        public void HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Int_Return_Method_Private_Modifier()
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
                        .WithMethod("HelloWorld", "int", meth =>
                        {
                            meth
                            .AsPrivate()
                            .WithBody("return 100;");
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
        private int HelloWorld()
        {
            return 100;
        }
    }
}", file);
    }

    [TestMethod]
    public void String_Return_Method_Internal_Modifier()
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
                        .WithMethod("HelloWorld", "string", meth =>
                        {
                            meth
                            .AsInternal()
                            .WithBody(@"var s = ""hello"";
return s;
");
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
        internal string HelloWorld()
        {
            var s = ""hello"";
            return s;
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Async_Method_UnEnforced_Task()
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
                            meth.AsPublic().AsAsync(false);
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
        public async void HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Async_Method_Enforced_Task()
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
                            meth.AsPublic().AsAsync();
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
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Async_Method_Enforced_Task_Int()
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
                        .WithMethod("HelloWorld", "int", meth =>
                        {
                            meth.AsPublic().AsAsync();
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
        public async Task<int> HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Async_Method_Enforced_Task_StringBuilder()
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
                        .WithMethod("HelloWorld", typeof(StringBuilder), meth =>
                        {
                            meth.AsPublic().AsAsync();
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
        public async Task<StringBuilder> HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void String_Return_Method_Internal_Unsafe_Modifier()
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
                        .WithMethod("HelloWorld", "string", meth =>
                        {
                            meth
                            .AsInternal()
                            .AsUnsafe()
                            .WithBody(@"var s = ""hello"";
return s;
");
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
        internal unsafe string HelloWorld()
        {
            var s = ""hello"";
            return s;
        }
    }
}", file);
    }

}
