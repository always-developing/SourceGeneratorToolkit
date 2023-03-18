using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class FieldTest
{
    [TestMethod]
    public void Class_Default_Field()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.AddField("int", "myIntField");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        int myIntField;
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Int_Field_Value()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddField("int", "myIntField", field =>
                        {
                            field
                            .AsPublic()
                            .WithValue("100");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public int myIntField = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Int_Field_Value()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddField("string", "myStringField", field =>
                        {
                            field
                            .AsInternal()
                            .WithValue(@"""value""");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        internal string myStringField = ""value"";
    }
}", file);
    }

    [TestMethod]
    public void Class_Protected_Int_Field_Readonly_Value()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddField("int", "myIntField", field =>
                        {
                            field
                            .AsProtected()
                            .AsReadOnly()
                            .WithValue("100");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        protected readonly int myIntField = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Int_Field_Readonly_Static_Value()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddField("int", "myIntField", field =>
                        {
                            field
                            .AsInternal()
                            .AsStatic()
                            .AsReadOnly()
                            .WithValue("100");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        internal static readonly int myIntField = 100;
    }
}", file);
    }
}
