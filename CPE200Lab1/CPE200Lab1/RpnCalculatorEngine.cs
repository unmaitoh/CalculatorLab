using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CPE200Lab1
{
    class RpnCalculatorEngine : CalculatorEngine
    {
        public void testStackMethod()
        {
            Stack testStack = new Stack();
            testStack.Push("1st element");
            testStack.Push("2nd element");
            testStack.Pop();
            Console.Out.WriteLine(testStack.Pop());
        }
    }

   
}
