using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class AttribtueTests
{
    [TestMethod]
    public void Empty_Class_Default_Attribute()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.AddAttribute("Serializable");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_OneValue_Attribute()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att.AddArgument("1");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable(1)]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_OneNamedValue_Attribute()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att.AddArgument("intValue", "1");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable(intValue = 1)]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_MultiValue_Attribute()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att
                            .AddArgument("1")
                            .AddArgument(@"""hello""");
                        })
                        .AsPublic();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable(1, ""hello"")]
    public class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_MultiNamedValue_Attribute()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att.AddArgument("intValue", "1")
                            .AddArgument("hello", @"""world""");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable(intValue = 1, hello = ""world"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Attributes()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable")
                        .AddAttribute("OtherAttribute");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable]
    [OtherAttribute]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Attributes_Named()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att
                            .AddArgument("intValue", "1")
                            .AddArgument("hello", @"""world""");
                        })
                        .AddAttribute("OtherAttribute", att =>
                        {
                            att
                            .AddArgument("doubleValue", "1.00");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [Serializable(intValue = 1, hello = ""world"")]
    [OtherAttribute(doubleValue = 1.00)]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Default_Attribute_Targets()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddAttribute("Serializable", att =>
                        {
                            att.TargetsType(AttributeTargets.Method);
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [method: Serializable]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Attribute_Usage()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("ClassMethodTargetAttribute ", cls =>
                    {
                        cls.AddAttribute("AttributeUsage", att =>
                        {
                            att.AddArgument("AttributeTargets.Class | AttributeTargets.Method");
                        })
                        .AsPublic()
                        .WithInheritence("Attribute");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClassMethodTargetAttribute : Attribute
    {
    }
}", file);
    }
}
