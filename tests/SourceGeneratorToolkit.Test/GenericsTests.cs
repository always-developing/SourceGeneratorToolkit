﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class GenericsTests
{
    [TestMethod]
    public void Empty_Class_One_Generic()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.AddGeneric("T");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T>
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Generic()
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
                        .AddGeneric("T")
                        .AddGeneric("T2"); ;
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T, T2>
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_One_Generic_One_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddGeneric("T")
                            .WithGenericConstraint("T", "new()");

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T>
        where T : new()
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_One_Generic_Multi_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddGeneric("T")
                        .WithGenericConstraint("T", "new()")
                        .WithGenericConstraint("T", "ITemp");

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T>
        where T : new(), ITemp
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Generic_One_Constraint()
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
                        .AddGeneric("T")
                        .AddGeneric("T1")
                        .WithGenericConstraint("T", "new()");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T, T1>
        where T : new()
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Generic_Multi_Constraint()
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
                        .AddGeneric("T")
                        .AddGeneric("T1")
                        .WithGenericConstraint("T", "new()")
                        .WithGenericConstraint("T1", "new()")
                        .WithGenericConstraint("T", "ITemp");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T, T1>
        where T : new(), ITemp where T1 : new()
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_One_Generic_Multi_Constraint_Inherits()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.AddGeneric("T")
                        .WithInheritence("StringBuilder")
                        .WithGenericConstraint("T", "new()")
                        .WithGenericConstraint("T", "ITemp");

                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T> : StringBuilder where T : new(), ITemp
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Class_Multi_Generic_Multi_Constraint_Inherits()
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
                        .AddGeneric("T")
                        .AddGeneric("T1")
                        .WithGenericConstraint("T", "new()")
                        .WithGenericConstraint("T1", "new()")
                        .WithInheritence("Task")
                        .WithGenericConstraint("T", "ITemp");
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    class myClass<T, T1> : Task where T : new(), ITemp where T1 : new()
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Method_One_Generic()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("Hello", "void", mthd =>
                        {
                            mthd.AddGeneric("T");
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
        void Hello<T>()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Method_Multi_Generic()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("Hello", "void", mthd =>
                        {
                            mthd.AddGeneric("T")
                            .AddGeneric("T1")
                            .AddGeneric("T2");
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
        void Hello<T, T1, T2>()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Internal_Method_One_Generic_One_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("myMethod", "void", mthd =>
                        {
                            mthd.AddGeneric("T")
                                .WithGenericConstraint("T", "new()")
                                .AsInternal();
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
        internal void myMethod<T>()
            where T : new()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Static_Method_One_Generic_Multi_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("myMethod", "void", mthd =>
                        {
                            mthd.AddGeneric("T")
                                .WithGenericConstraint("T", "new()")
                                .WithGenericConstraint("T", "class")
                                .AsStatic();
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
        static void myMethod<T>()
            where T : new(), class
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Private_Method_Multi_Generic_One_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("myMethod", "void", mthd =>
                        {
                            mthd
                            .AddGeneric("T")
                            .AddGeneric("T1")
                            .WithGenericConstraint("T", "new()")
                            .AsPrivate();
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
        private void myMethod<T, T1>()
            where T : new()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Proteced_Method_Multi_Generic_Multi_Constraint()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("myMethod", "void", mthd =>
                        {
                            mthd
                            .AddGeneric("T")
                            .AddGeneric("T1")
                            .AddGeneric("T2")
                            .WithGenericConstraint("T", "new()")
                            .WithGenericConstraint("T1", "new()")
                            .WithGenericConstraint("T", "class")
                            .AsProtected();
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
        protected void myMethod<T, T1, T2>()
            where T : new(), class where T1 : new()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Proteced_Method_Multi_Generic_Multi_Constraint_Enum()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("myMethod", "void", mthd =>
                        {
                            mthd
                            .AddGeneric("T")
                            .AddGeneric("T1")
                            .AddGeneric("T2")
                            .WithGenericConstraint("T", GenericConstraint.New)
                            .WithGenericConstraint("T1", GenericConstraint.New)
                            .WithGenericConstraint("T", GenericConstraint.Class)
                            .AsProtected();
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
        protected void myMethod<T, T1, T2>()
            where T : new(), class where T1 : new()
        {
        }
    }
}", file);
    }
}
