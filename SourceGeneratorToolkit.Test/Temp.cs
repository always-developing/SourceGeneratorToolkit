//extern alias NS1;
//extern alias NS2;

using SourceGeneratorToolkit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceGeneratorToolkit.Test
{
    public unsafe struct MyStruct<T> where T : new()
    {
        public static async Task<int> GetInt()
        {
            return 0;
        }
    }

    public unsafe record MyRec(string Name)
    {
        public unsafe virtual Guid Id { get; private protected init ; }

        public int MyInt;

    }

    public class myclass
    {
        private protected myclass()
        {
            
        }
    }

}

public abstract class Temp//<T> : Task, IDisposable where T : new()
{
    //public abstract int myint = 100;

    public int MyValue { protected internal get; set; }

    public Temp(Action action)
    {
    }

    public void MyMethod(in int value)
    {

    }

    
}

public class Temp2 : Temp
{
    protected internal enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    public Temp2(Action action) : base(action)
    {
    }
}

public unsafe interface ITemp<T>
{
    public virtual int MyMethod()
    {
        return 0;
    }
}


