using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.SampleApp;


[Obsolete(message:"error", error:true)]
public class MyClass //: MyOtherClass
{
    [Obsolete(message: "error", error: true)]
    public async Task MyMethod()
    {

    }
}
