// See https://aka.ms/new-console-template for more information
using Autofac;
using Autofac.Extras.DynamicProxy;
using Core1;
using CustomNameSpace.Foo;
using Firex;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer();

            // Create a lifetime scope which we can use to resolve services
            // https://autofac.readthedocs.io/en/latest/resolve/index.html#resolving-services
            using var scope = container.BeginLifetimeScope();
            
            var foo = scope.Resolve<IFoo>();


            foo.Method1();

            var res = foo.Method2("Test");

            Console.WriteLine($"Response: {res}");
        }
        
        private static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DynamicInterceptor>();
            // Register our label maker service as a singleton
            // (so we only create a single instance)
            builder.RegisterType<Foo>()
                .As<IFoo>()
                .SingleInstance()
                .EnableInterfaceInterceptors().InterceptedBy(typeof(DynamicInterceptor)); ;
            builder.RegisterType<Barley>().As<IBarley>();

            return builder.Build();
        }
    }
}