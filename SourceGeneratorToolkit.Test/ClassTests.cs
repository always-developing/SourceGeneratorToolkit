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
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_No_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithClass("myClass", cls => { });
            });
        }).Build();

        Assert.AreEqual(@"class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_No_Namespace_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithClass("myClass", cls => { })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;

class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_NoModifiers_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns;
class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    private class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Internal_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    internal class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Protected_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    protected class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_File_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    file class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns;
public class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns;
private class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Private_Abstract_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns;
private abstract class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Abstract_Trad_Namespace()
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
                        .AsPublic()
                        .AsAbstract();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public abstract class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Public_Static_Trad_Namespace()
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
                        .AsPublic()
                        .AsStatic();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    public static class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Protected_Partial_Static_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns;
protected partial static class myClass
{
}", file);
    }

    [TestMethod]
    public void Empty_Class_Internal_Partial_Sealed_Static_Filescoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
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
        }).Build();

        Assert.AreEqual(@"namespace testns;
protected partial sealed static class myClass
{
}", file);
    }
}
