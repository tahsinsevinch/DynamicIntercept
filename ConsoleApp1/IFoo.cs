using Autofac.Extras.DynamicProxy;
using ConsoleApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomNameSpace.Foo
{
    public interface IFoo
    {
        void Method1();
        int Method2(string Name);
    }

    public class Foo : IFoo
    {
        public void Method1()
        {
            Console.WriteLine("Method1 Executed");
        }

        public int Method2(string Name)
        {
            Console.WriteLine($"Method2 Executed: {Name}");
            return 90;
        }
    }
}
