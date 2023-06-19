using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ConstructorTests
{
    [TestMethod]
    public void Default_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.WithConstructor();
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
        }
    }
}", file);
    }

    [TestMethod]
    public void One_Param_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb.AddParameter("int", "abc");
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
        myClass(int abc)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Multi_Param_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("int", "abc")
                            .AddParameter("string", "stringValue");
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
        myClass(int abc, string stringValue)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Multi_Param_Public_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("int", "abc")
                            .AddParameter("Type", "testType")
                            .AsPublic();
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
        public myClass(int abc, Type testType)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void One_Param_Protected_Internal_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("Class<T>", "@class")
                            .AsProtectedInternal();
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
        protected internal myClass(Class<T> @class)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Default_Constructor_Base()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(con =>
                        {
                            con.CallsBase();
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
        myClass() : base()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Default_Constructor_Base_With_Argument()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(con =>
                        {
                            con.CallsBase(arg =>
                            {
                                arg.AddArgument("10")
                                .AddArgument(@"""hello""");
                            });
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
        myClass() : base(10, ""hello"")
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Default_Constructor_This()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(con =>
                        {
                            con.CallsThis();
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
        myClass() : this()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Default_Constructor_This_With_Argument()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(con =>
                        {
                            con.CallsThis(arg =>
                            {
                                arg.AddArgument("10")
                                .AddArgument("33");
                            });
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
        myClass() : this(10, 33)
        {
        }
    }
}", file);
    }
}
