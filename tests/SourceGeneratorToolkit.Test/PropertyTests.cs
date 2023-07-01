using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class PropertyTests
{
    [TestMethod]
    public void Class_Default_Property()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder.AsPublic();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Property_DefaultValue()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsInternal()
                            .WithValue("100");
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        internal int myIntField { get; set; } = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_No_Getter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithNoGetter();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_No_Setter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithNoSetter();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { get; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_With_Initer()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithIniter();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { get; init; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Virtual_Property()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .AsVirtual();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public virtual int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_Internal_Set()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithGetter(builder =>
                            {
                                builder.AsInternal();
                            });

                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { internal get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_No_Getter_Private_Set()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .WithNoGetter()
                            .WithSetter(builder =>
                            {
                                builder.AsPrivate();
                            });
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public int myIntField { private set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Required_Property()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty("int", "myIntField", builder =>
                        {
                            builder
                            .AsPublic()
                            .AsRequired();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public required int myIntField { get; set; }
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Property_WithType()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddProperty(typeof(Task), "myTaskField", builder =>
                        {
                            builder.AsPublic();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        public Task myTaskField { get; set; }
    }
}", file);
    }
}
