using Core1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firex
{
    public class Barley : IBarley
    {
        public void MethodBarley()
        {
            Console.WriteLine("Barley Shared Method Run");
        }
    }
}
