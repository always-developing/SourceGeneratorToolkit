using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test;

[TestClass]
public class StructTests
{
    [TestMethod]
    public void Empty_Struct_Trad_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithStruct("TestStruct", cls => { });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns
{
    struct TestStruct
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Struct_Public_FileScoped_Namespace()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithStruct("TestStruct", str => 
                    {
                        str.AsPublic();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns;
public struct TestStruct
{
}", file);
    }

    [TestMethod]
    public void Empty_Struct_Internal_Readonly()
    {
        var file = SourceGenerator.Generate(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithStruct("TestStruct", str =>
                    {
                        str.AsInternal()
                        .AsReadOnly();
                    });
                });
            });
        }).Build();

        Assert.AreEqual(@"namespace testns;
internal readonly struct TestStruct
{
}", file);
    }
}
