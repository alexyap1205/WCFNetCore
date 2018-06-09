using System;
using System.Collections.Generic;
using System.Text;
using WCFService;

namespace WCFClientCore
{
    class CallbackHandler : ICalculatorDuplexCallback
    {
        public void Equals(double result)
        {
            Console.WriteLine($"Equals: {result}");
        }

        public void Equation(string eqn)
        {
            Console.WriteLine($"Equation: {eqn}");
        }
    }
}
