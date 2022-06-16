using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AspectList
    {
       public static List<Aspect> list = new List<Aspect>()
       {
           new Aspect{
               MethodFullName="CustomNameSpace.Foo.IFoo",
               MethodName="Method1",
               BeforeRun=true,
               RunFullName="ConsoleApp1.LocalPlugin",
               RunMethod="Test"
           },
           new Aspect{
               MethodFullName="CustomNameSpace.Foo.IFoo",
               MethodName="Method2",
               AfterRun=true,
               RunAssemblyName="Plugin/Plugin1.dll",
               RunFullName="Plugin1.MyPlugin",
               RunMethod="PluginAfter"
           }
       };
    }
}
