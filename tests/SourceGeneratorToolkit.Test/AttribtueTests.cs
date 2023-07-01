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
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [Serializable]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_OneValue_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [Serializable(1)]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_OneNamedValue_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [Serializable(intValue = 1)]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_MultiValue_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [Serializable(1, ""hello"")]
    public class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_MultiNamedValue_Attribute()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [Serializable(intValue = 1, hello = ""world"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Attributes()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
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
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
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
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [method: Serializable]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Attribute_Usage()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ClassMethodTargetAttribute : Attribute
    {
    }
}", file);
    }
}
