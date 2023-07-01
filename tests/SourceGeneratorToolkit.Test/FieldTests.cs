using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class FieldTests
{
    [TestMethod]
    public void Class_Default_Field()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
        int myIntField;
    }
}", file);
    }

    [TestMethod]
    public void Class_Public_Int_Field_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
                            .WithDefaultValue("100");
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
        public int myIntField = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Int_Field_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
                            .WithDefaultValue(@"""value""");
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
        internal string myStringField = ""value"";
    }
}", file);
    }

    [TestMethod]
    public void Class_Protected_Int_Field_Readonly_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
                            .WithDefaultValue("100");
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
        protected readonly int myIntField = 100;
    }
}", file);
    }

    [TestMethod]
    public void Class_Internal_Int_Field_Readonly_Static_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
                            .WithDefaultValue("100");
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
        internal static readonly int myIntField = 100;
    }
}", file);
    }

    [TestMethod]
    public void Interface_Default_Field()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithInterface("IMyInterface", cls =>
                    {
                        cls.AddField("int", "myIntField");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    interface IMyInterface
    {
        int myIntField;
    }
}", file);
    }
}
