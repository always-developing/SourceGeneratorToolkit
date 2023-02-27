using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit;

[TestClass]
public class ConstructorTests
{
    [TestMethod]
    public void Class_Default_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls => 
                    {
                        cls.WithConstructor();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
                
        myClass()
        {
        }

    }
}

", file);
    }

    [TestMethod]
    public void Class_One_Param_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb.AddParameter("int", "abc");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
                
        myClass(int abc)
        {
        }

    }
}

", file);
    }

    [TestMethod]
    public void Class_Multi_Param_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("int", "abc")
                            .AddParameter("string", "stringValue");
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
                
        myClass(int abc, string stringValue)
        {
        }

    }
}

", file);
    }

    [TestMethod]
    public void Class_Multi_Param_Public_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("int", "abc")
                            .AddParameter("Type", "testType")
                            .AsPublic();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
                
        public myClass(int abc, Type testType)
        {
        }

    }
}

", file);
    }

    [TestMethod]
    public void Class_One_Param_Protected_Internal_Constructor()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithClass("myClass", cls =>
                    {
                        cls.WithConstructor(cb =>
                        {
                            cb
                            .AddParameter("Class<T>", "@class")
                            .AsProtectedInternal();
                        });
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    class myClass
    {
                
        protected internal myClass(Class<T> @class)
        {
        }

    }
}

", file);
    }
}
