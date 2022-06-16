using Autofac;
using Core1;

namespace Plugin1
{
    public class MyPlugin
    {
        private readonly ILifetimeScope provider;
        public MyPlugin(ILifetimeScope provider)
        {
            this.provider = provider;
        }
        public void PluginBefore()
        {
            Console.WriteLine("Plugin run before method");
        }
        public void PluginAfter(int result)
        {
            var barley = provider.Resolve<IBarley>();
            barley.MethodBarley();
            Console.WriteLine($"Plugin run after method {result}");
        }
    }
}