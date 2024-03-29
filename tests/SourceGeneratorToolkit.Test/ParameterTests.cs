﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class ParameterTests
{
    [TestMethod]
    public void Single_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue");
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
        void HelloWorld(int intValue)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Multi_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue")
                            .AddParameter("string", "myString");
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
        void HelloWorld(int intValue, string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void In_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue", p => p.AsIn())
                            .AddParameter("string", "myString");
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
        void HelloWorld(in int intValue, string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Out_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue")
                            .AddParameter("string", "myString", p => p.AsOut());
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
        void HelloWorld(int intValue, out string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Ref_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue", p => p.AsRef())
                            .AddParameter("string", "myString", p => p.AsRef());
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
        void HelloWorld(ref int intValue, ref string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void In_Out_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue", p => p.AsIn().AsOut())
                            .AddParameter("string", "myString");
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
        void HelloWorld(out int intValue, string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Multi_Ref_Out_Parameter()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue", p => p.AsRef())
                            .AddParameter("string", "myString", p => p.AsOut());
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
        void HelloWorld(ref int intValue, out string myString)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Single_Parameter_Default_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue", p =>
                            {
                                p.WithDefaultValue("100");
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
        void HelloWorld(int intValue = 100)
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Multi_Parameter_Default_Value()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void", m =>
                        {
                            m.AddParameter("int", "intValue")
                            .AddParameter("string", "myString", p =>
                            {
                                p.WithDefaultValue(@"""defaultValue""");
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
        void HelloWorld(int intValue, string myString = ""defaultValue"")
        {
        }
    }
}", file);
    }
}
