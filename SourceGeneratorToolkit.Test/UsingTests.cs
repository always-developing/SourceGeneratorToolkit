using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class UsingTests
{

    [TestMethod]
    public void One_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"using System;", file);
    }

    [TestMethod]
    public void Multi_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System")
                .WithUsing("System.Text")
                .WithUsing("System.IO");
            });
        }).Build();

        Assert.AreEqual(@"using System;
using System.IO;
using System.Text;", file);
    }

    [TestMethod]
    public void One_External_Alias()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample");
            });
        }).Build();

        Assert.AreEqual(@"extern alias MyExample;", file);
    }

    [TestMethod]
    public void Multi_External_Alias()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample")
                .WithExternAlias("MyOtherExample"); 
            });
        }).Build();

        Assert.AreEqual(@"extern alias MyExample;
extern alias MyOtherExample;", file);
    }

    [TestMethod]
    public void Multi_External_Alias_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample")
                .WithExternAlias("MyOtherExample")
                .WithUsing("System");
            });
        }).Build();

        Assert.AreEqual(@"extern alias MyExample;
extern alias MyOtherExample;

using System;", file);
    }

    [TestMethod]
    public void One_Static_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System", use =>
                {
                    use.AsStatic();
                });
            });
        }).Build();

        Assert.AreEqual(@"using static System;", file);
    }

    [TestMethod]
    public void Multi_Static_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
               .WithUsing("System", u => u.AsStatic())
               .WithUsing("System.Text", u => u.AsStatic())
               .WithUsing("System.IO", u => u.AsStatic());
            });
        }).Build();

        Assert.AreEqual(@"using static System;
using static System.IO;
using static System.Text;", file);
    }

    [TestMethod]
    public void Multi_Static_And_NonStatic_Using()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
               .WithUsing("System", u => u.AsStatic())
               .WithUsing("System.Text", u => u.AsStatic())
               .WithUsing("System.IO");
            });
        }).Build();

        Assert.AreEqual(@"using static System;
using System.IO;
using static System.Text;", file);
    }

    //    [TestMethod]
    //    public void One_Using_Tree()
    //    {
    //        var tree = SourceGenerator.Generate(gen =>
    //        {
    //            gen.WithFile("file1", file =>
    //            {
    //                file.WithUsing("System");
    //            });
    //        }).ToTree();

    //        Assert.AreEqual(@"|-Generator
    // |-FileContainer (file1)
    //  |-UsingsContainer
    //   |-UsingStatemment
    //", tree);
    //    }

    //    [TestMethod]
    //    public void Multi_Using_Tree()
    //    {
    //        var tree = SourceGenerator.Generate(gen =>
    //        {
    //            gen.WithFile("file1", file =>
    //            {
    //                file.WithUsing("System")
    //                .WithUsing("System.IO");
    //            });
    //        }).ToTree();

    //        Assert.AreEqual(@"|-Generator
    // |-FileContainer (file1)
    //  |-UsingsContainer
    //   |-UsingStatemment
    //   |-UsingStatemment
    //", tree);
    //    }
}
