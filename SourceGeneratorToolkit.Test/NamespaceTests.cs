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
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => { });
            });
        }).Build();

        Assert.AreEqual(@"namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Namespace_Multi_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_No_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("tstNamespace", ns => { });
            });
        }).Build();

        Assert.AreEqual(@"namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_One_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithFilescopedNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns => { })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;
using System.IO;

namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Empty_Duplicate_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => { });
                file.WithNamespace("tstNamespace2", ns => { });
            });
        }).Build();

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
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("tstNamespace", ns => { });
                file.WithFilescopedNamespace("tstNamespace2", ns => { });
            });
        }).Build();

        Assert.AreEqual(@"namespace tstNamespace;
namespace tstNamespace2;", file);
    }

    [TestMethod]
    public void Empty_Namespace_No_Using_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => { });
            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
  |-TraditionalNamespaceContainer
", tree);

    }

    [TestMethod]
    public void Empty_Filescoped_Namespace_No_Using_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("tstNamespace", ns => { });
            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
  |-FilescopedNamespaceContainer
", tree);

    }

//    [TestMethod]
//    public void Empty_Namespace_Using_Tree()
//    {
//        var tree = SourceGenerator.Generate(gen =>
//        {
//            gen.WithFile("file1", file =>
//            {
//                file
//                .WithUsing("System")
//                .WithNamespace("tstNamespace", ns => { });
//            });
//        }).ToTree();

//        Assert.AreEqual(@"|-Generator
// |-FileContainer (file1)
//  |-UsingsContainer
//   |-UsingStatemment
//  |-TraditionalNamespaceContainer
//", tree);

//    }

//    [TestMethod]
//    public void Empty_Namespace_Multi_Using_Tree()
//    {
//        var tree = SourceGenerator.Generate(gen =>
//        {
//            gen.WithFile("file1", file =>
//            {
//                file
//                .WithUsing("System.IO")
//                .WithNamespace("tstNamespace", ns => { })
//                .WithUsing("System");
//            });
//        }).ToTree();

//        Assert.AreEqual(@"|-Generator
// |-FileContainer (file1)
//  |-UsingsContainer
//   |-UsingStatemment
//   |-UsingStatemment
//  |-TraditionalNamespaceContainer
//", tree);
//    }


    [TestMethod]
    public void Public_Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns => 
                {
                    ns.AsPublic();
                })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;

public namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Internal_Empty_Namespace_One_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithNamespace("tstNamespace", ns =>
                {
                    ns.AsInternal();
                })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;

internal namespace tstNamespace
{
}", file);
    }

    [TestMethod]
    public void Public_Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns => 
                {
                    ns.AsPublic();
                })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;
using System.IO;

public namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Internal_Empty_Filescoped_Namespace_Multi_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System.IO")
                .WithFilescopedNamespace("tstNamespace", ns =>
                {
                    ns.AsInternal();
                })
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;
using System.IO;

internal namespace tstNamespace;", file);
    }

    [TestMethod]
    public void Trad_Namespace_In_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("tstNamespace", ns => 
                {
                    ns.WithNamespace("otherNamespace", ns1 => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace tstNamespace
{
    namespace otherNamespace
    {
    }
}", file);
    }
}
