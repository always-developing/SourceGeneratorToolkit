using SourceGeneratorToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ClassTests
{
    [TestMethod]
    public void Empty_Class_NoModifiers_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_No_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithClass("myClass", cls => { });
            });
        });

        Assert.AreEqual(@"[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_No_Namespace_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithClass("myClass", cls => { })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;

[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    { 
                        cls.AsPublic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsPrivate();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    private class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Internal_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsInternal();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    internal class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Protected_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsProtected();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    protected class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_File_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsFile();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    file class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsPublic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
public class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AsPrivate();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
private class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Abstract_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsPrivate()
                        .AsAbstract();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
private abstract class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Abstract_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsPublic()
                        .AsAbstract();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public abstract class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Static_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsPublic()
                        .AsStatic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    public static class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Protected_Partial_Static_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsProtected()
                        .AsPartial()
                        .AsStatic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
protected partial static class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Internal_Partial_Sealed_Static_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsProtected()
                        .AsPartial()
                        .AsStatic()
                        .AsSealed();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
protected partial sealed static class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Unsafe_Static_Filescoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls
                        .AsUnsafe()
                        .AsStatic();
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
unsafe static class myClass
{
}", file);
    }
}
