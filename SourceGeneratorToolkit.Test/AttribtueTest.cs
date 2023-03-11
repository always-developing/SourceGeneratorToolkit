using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class AttribtueTest
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
                        cls.WithAttribute("Serializable");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
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
                        cls.WithAttribute("Serializable", att =>
                        {
                            att.AddArgument("1");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
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
                        cls.WithAttribute("Serializable", att =>
                        {
                            att.AddArgument("intValue", "1");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
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
                        cls.WithAttribute("Serializable", att =>
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
                        cls.WithAttribute("Serializable", att =>
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
    [Serializable(intValue = 1, hello = ""world"")]
    class myClass
    {
    }
}", file);
    }
}
