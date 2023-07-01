using System;
using System.Collections.Generic;
using System.Drawing;
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
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    /// <summary>
    /// Description for 'myClass'
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_Summary_Single_Blank_Comment()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
    public void Class_Summary_Single_Multi_Comment()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns
{
    /// <summary>
    /// Summary line 1
    /// Summary line 2
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Class_Summary_Single_Comment_Param()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddDocumentation(doc =>
                        {
                            doc
                                .WithSummary("Description for 'myClass'")
                                .AddParam("NoParam", "Class still allows params");
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    /// <summary>
    /// Description for 'myClass'
    /// </summary>
    /// <param name = ""NoParam"">Class still allows params</param>
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass
    {
    }
}", file);
    }

    [TestMethod]
    public void Method_Summary_Single_Comment_Param()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", mthd =>
                        {
                            mthd.AddParameter("int", "myInt")
                            .AddDocumentation(doc =>
                            {
                                doc.WithSummary("My method")
                                .AddParam("myInt", "my int parameter");
                            });

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
        /// <summary>
        /// My method
        /// </summary>
        /// <param name = ""myInt"">my int parameter</param>
        void HelloWorld(int myInt)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Method_Summary_Single_Comment_Returns()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", mthd =>
                        {
                            mthd.AddParameter("int", "myInt")
                            .AddDocumentation(doc =>
                            {
                                doc.WithSummary("My method")
                                .WithReturns("doesn't return a value");
                            });

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
        /// <summary>
        /// My method
        /// </summary>
        /// <returns>
        /// doesn't return a value
        /// </returns>
        void HelloWorld(int myInt)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Method_Summary_Multi_Comment_Multi_Returns()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", mthd =>
                        {
                            mthd.AddParameter("int", "myInt")
                            .AddDocumentation(doc =>
                            {
                                doc.WithSummary(new string[] { "My method", "line2" })
                                .WithReturns(new string[] { "doesn't return a value", "definitely not" });
                            });

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
        /// <summary>
        /// My method
        /// line2
        /// </summary>
        /// <returns>
        /// doesn't return a value
        /// definitely not
        /// </returns>
        void HelloWorld(int myInt)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Method_Summary_Comment_Param_Returns()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", mthd =>
                        {
                            mthd.AddParameter("int", "myInt")
                            .AddDocumentation(doc =>
                            {
                                doc.WithSummary("My method")
                                .AddParam("myInt", "my int param")
                                .WithReturns("doesn't return a value");
                            });

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
        /// <summary>
        /// My method
        /// </summary>
        /// <param name = ""myInt"">my int param</param>
        /// <returns>
        /// doesn't return a value
        /// </returns>
        void HelloWorld(int myInt)
        {
        }
    }
}", file);
    }
}
