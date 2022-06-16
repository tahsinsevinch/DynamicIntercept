using Autofac;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class DynamicInterceptor : IInterceptor
    {
        private readonly ILifetimeScope collection;
        public DynamicInterceptor(ILifetimeScope collection)
        {
            this.collection = collection;
        }
        /// <inheritdoc />
        public void Intercept(IInvocation invocation)
        {
            var aspect = AspectList.list.Where(x => x.MethodName == invocation.Method.Name && x.MethodFullName == invocation.Method.DeclaringType.FullName).ToList();
            if (aspect.Count > 0) {
                foreach (var item in aspect.Where(x=>x.BeforeRun).ToList())
                {
                    ExecuteMethod(item,invocation.Arguments);
                }
            }
            invocation.Proceed();
            if (aspect.Count > 0)
            {
                foreach (var item in aspect.Where(x => x.AfterRun).ToList())
                {
                    ExecuteMethod(item, new object[] { invocation.ReturnValue });
                }
            }
        }
        private void ExecuteMethod(Aspect item, object[] arguments)
        {
            var asm = String.IsNullOrEmpty(item.RunAssemblyName) ? Assembly.GetEntryAssembly() : Assembly.LoadFrom(item.RunAssemblyName);
            Type t = asm.GetType(item.RunFullName);
            ConstructorInfo magicConstructor = t.GetConstructors()[0];

            object magicClassObject = magicConstructor.Invoke(new object[] { collection});

            var methodInfo = t.GetMethod(item.RunMethod);
            if (methodInfo == null)
            {
                // never throw generic Exception - replace this with some other exception type
                throw new Exception("No such method exists.");
            }
            methodInfo.Invoke(magicClassObject, arguments);
            Console.WriteLine($"Run:{item.RunFullName}-{item.RunMethod}");
        }

        private static object GetDefaultValue(Type type)
        {
            if (type.IsEnum) return type.GetEnumValues().GetValue(0);
            if (type.IsValueType) return Activator.CreateInstance(type);
            return null;
        }
    }
}
