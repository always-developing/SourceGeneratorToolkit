using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class EnumTest
{
    [TestMethod]
    public void Enum_No_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", ec => 
                    {
                        ec
                        .AddMember("Spring")
                        .AddMember("Summer")
                        .AddMember("Autumn")
                        .AddMember("Winter");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
}", file);
    }

    [TestMethod]
    public void Enum_With_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", ec =>
                    {
                        ec
                        .AddMember("Spring", "1")
                        .AddMember("Summer", "2")
                        .AddMember("Autumn", "3")
                        .AddMember("Winter", "4");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season
    {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4
    }
}", file);
    }

    [TestMethod]
    public void Enum_With_Param_Type_No_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", "ushort", ec =>
                    {
                        ec
                        .AddMember("Spring")
                        .AddMember("Summer")
                        .AddMember("Autumn")
                        .AddMember("Winter");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season : ushort
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
}", file);
    }

    [TestMethod]
    public void Enum_With_Method_Type_No_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", ec =>
                    {
                        ec
                        .OfType("ushort")
                        .AddMember("Spring")
                        .AddMember("Summer")
                        .AddMember("Autumn")
                        .AddMember("Winter");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season : ushort
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }
}", file);
    }

    [TestMethod]
    public void Enum_With_Param_Type_With_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", "ushort", ec =>
                    {
                        ec
                        .AddMember("Spring", "1")
                        .AddMember("Summer", "2")
                        .AddMember("Autumn", "3")
                        .AddMember("Winter", "4");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season : ushort
    {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4
    }
}", file);
    }

    [TestMethod]
    public void Enum_With_Method_Type_With_Values()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithEnum("Season", ec =>
                    {
                        ec
                        .OfType("ushort")
                        .AddMember("Spring", "1")
                        .AddMember("Summer", "2")
                        .AddMember("Autumn", "3")
                        .AddMember("Winter", "4");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""1.0.0.0"")]
    enum Season : ushort
    {
        Spring = 1,
        Summer = 2,
        Autumn = 3,
        Winter = 4
    }
}", file);
    }
}
