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
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithNamespace("testns", ns =>
                {
                    ns.WithStruct("TestStruct", cls => { });
                });
            });
        });

        Assert.AreEqual(@"namespace testns
{
    [System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
    struct TestStruct
    {
    }
}", file);
    }

    [TestMethod]
    public void Empty_Struct_Public_FileScoped_Namespace()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
public struct TestStruct
{
}", file);
    }

    [TestMethod]
    public void Empty_Struct_Internal_Readonly()
    {
        var file = SourceGenerator.GenerateSource(gen =>
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
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
internal readonly struct TestStruct
{
}", file);
    }

    [TestMethod]
    public void Struct_With_Public_Async_Method()
    {
        var file = SourceGenerator.GenerateSource(gen =>
        {
            gen.WithFile("file1", file =>
            {
                file.WithFilescopedNamespace("testns", ns =>
                {
                    ns.WithStruct("TestStruct", str =>
                    {
                        str.AsPublic()
                        .WithMethod("GetIntAsync", "int", mthd =>
                        {
                            mthd.AsPublic().AsAsync();
                        });
                    });
                });
            });
        });

        Assert.AreEqual(@"namespace testns;
[System.CodeDom.Compiler.GeneratedCode(""SourceGeneratorToolkit"", ""0.0.0.1"")]
public struct TestStruct
{
    public async Task<int> GetIntAsync()
    {
    }
}", file);
    }
}
