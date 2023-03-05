﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class MethodTest
{
    [TestMethod]
    public void Empty_Method_No_Modifier()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithMethod("HelloWorld", "void");
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        void HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Empty_Method_Public_Modifier()
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
                        .WithMethod("HelloWorld", "void", meth =>
                        {
                            meth.AsPublic();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        public void HelloWorld()
        {
        }
    }
}", file);
    }

    [TestMethod]
    public void Int_Return_Method_Private_Modifier()
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
                        .WithMethod("HelloWorld", "int", meth =>
                        {
                            meth
                            .AsPrivate()
                            .AddStatement("return 100;");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        private int HelloWorld()
        {
            return 100;
        }
    }
}", file);
    }

    [TestMethod]
    public void String_Return_Method_Internal_Modifier()
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
                        .WithMethod("HelloWorld", "string", meth =>
                        {
                            meth
                            .AsInternal()
                            .AddStatement(@"var s = ""hello"";")
                            .AddStatement(@"return s;");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
        internal string HelloWorld()
        {
            var s = ""hello"";
            return s;
        }
    }
}", file);
    }
}
