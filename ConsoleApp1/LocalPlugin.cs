using Autofac;
using Core1;
using Firex;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class LocalPlugin
    {
        private readonly ILifetimeScope provider;
        public LocalPlugin(ILifetimeScope provider)
        {
            this.provider = provider;
        }
       public void Test()
        {
            var barley = provider.Resolve<IBarley>();
            barley.MethodBarley();
            Console.WriteLine("Bar Method Executed");
        }
    }
}
