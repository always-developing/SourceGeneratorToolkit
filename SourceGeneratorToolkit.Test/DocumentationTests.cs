using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class DocumentationTests
{
    [TestMethod]
    public void Class_Summary_Single_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddDocumentation(doc =>
                        {
                            doc.WithSummary("Description for 'myClass'");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    /// <summary>
    /// Description for 'myClass'
    /// </summary>
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_Summary_Single_Blank_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddDocumentation(doc =>
                        {
                        });
                    });
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
    public void Class_Summary_Single_Multi_Comment()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddDocumentation(doc =>
                        {
                            doc.WithSummary(new string[] { "Summary line 1", "Summary line 2" });
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    /// <summary>
    /// Summary line 1
    /// Summary line 2
    /// </summary>
    class myClass
    {
    }
}", file);
    }
}
