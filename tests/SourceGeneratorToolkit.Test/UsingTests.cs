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
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System");
            });
        });

        Assert.AreEqual(@"using System;", file);
    }

    [TestMethod]
    public void Multi_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System")
                .WithUsing("System.Text")
                .WithUsing("System.IO");
            });
        });

        Assert.AreEqual(@"using System;
using System.IO;
using System.Text;", file);
    }

    [TestMethod]
    public void One_External_Alias()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample");
            });
        });

        Assert.AreEqual(@"extern alias MyExample;", file);
    }

    [TestMethod]
    public void Multi_External_Alias()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample")
                .WithExternAlias("MyOtherExample"); 
            });
        });

        Assert.AreEqual(@"extern alias MyExample;
extern alias MyOtherExample;", file);
    }

    [TestMethod]
    public void Multi_External_Alias_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithExternAlias("MyExample")
                .WithExternAlias("MyOtherExample")
                .WithUsing("System");
            });
        });

        Assert.AreEqual(@"extern alias MyExample;
extern alias MyOtherExample;

using System;", file);
    }

    [TestMethod]
    public void One_Static_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System", use =>
                {
                    use.AsStatic();
                });
            });
        });

        Assert.AreEqual(@"using static System;", file);
    }

    [TestMethod]
    public void Multi_Static_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
               .WithUsing("System", u => u.AsStatic())
               .WithUsing("System.Text", u => u.AsStatic())
               .WithUsing("System.IO", u => u.AsStatic());
            });
        });

        Assert.AreEqual(@"using static System;
using static System.IO;
using static System.Text;", file);
    }

    [TestMethod]
    public void Multi_Static_And_NonStatic_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
               .WithUsing("System", u => u.AsStatic())
               .WithUsing("System.Text", u => u.AsStatic())
               .WithUsing("System.IO");
            });
        });

        Assert.AreEqual(@"using static System;
using System.IO;
using static System.Text;", file);
    }

    [TestMethod]
    public void One_Global_Using()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System", u =>
                {
                    u.AsGlobal();
                });
            });
        });

        Assert.AreEqual(@"global using System;", file);
    }

    [TestMethod]
    public void Multi_Using_One_Global()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file
                .WithUsing("System")
                .WithUsing("System.Text", u =>
                {
                    u.AsGlobal();
                })
                .WithUsing("System.IO");
            });
        });

        Assert.AreEqual(@"global using System.Text;
using System;
using System.IO;", file);
    }

    //    [TestMethod]
    //    public void One_Using_Tree()
    //    {
    //        var tree = SourceGenerator.GenerateSource(gen =>
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
    //        var tree = SourceGenerator.GenerateSource(gen =>
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
