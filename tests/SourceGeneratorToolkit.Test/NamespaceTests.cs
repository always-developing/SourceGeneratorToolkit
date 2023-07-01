using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class NamespaceTests
{
    [TestMethod]
    public void Empty_Namespace_No_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => { });
            });
        });

        Assert.AreEqual(@"namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Namespace_Multi_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_No_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("tstNamespace", ns => { });
            });
        });

        Assert.AreEqual(@"namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_One_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithFilescopedNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Duplicate_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => { });
                file.WithNamespace("tstNamespace2", ns => { });
            });
        });

        Assert.AreEqual(@"namespace tstNamespace
{
}

namespace tstNamespace2
{
}", file);
    }

    [TestMethod]
    public void Empty_Duplicate_Filescope_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("tstNamespace", ns => { });
                file.WithFilescopedNamespace("tstNamespace2", ns => { });
            });
        });

        Assert.AreEqual(@"namespace tstNamespace;
namespace tstNamespace2;", file);
    }

    [TestMethod]
    public void Public_Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns => 
                {                   
                })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Internal_Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns => {})
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Public_Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns => 
                {
                })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Internal_Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns =>
                {
                })
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Trad_Namespace_In_Trad_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => 
                {
                    ns.WithNamespace("otherNamespace", ns1 => { });
                });
            });
        });

        Assert.AreEqual(@"namespace tstNamespace
{
    namespace otherNamespace
    {
    }
}", file);
    }
}
