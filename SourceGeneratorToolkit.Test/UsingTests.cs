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

        Assert.AreEqual(@"using System;

", file);
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
using System.Text;

", file);
    }

    [TestMethod]
    public void One_Using_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System");
            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
  |-UsingsContainer
   |-UsingStatemment
", tree);
    }

    [TestMethod]
    public void Multi_Using_Tree()
    {
        var tree = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithUsing("System")
                .WithUsing("System.IO");
            });
        }).ToTree();

        Assert.AreEqual(@"|-Generator
 |-FileContainer (file1)
  |-UsingsContainer
   |-UsingStatemment
   |-UsingStatemment
", tree);
    }
}
