using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03
{
    public class Simple
    {
        private int myVar;

        public int MyProperty
        {
            get => myVar;
            set => myVar = value;
        }

        public void DoWork(int a, int b)
        {
            if (a > b) Console.WriteLine(a - b); 
            else Console.WriteLine(0);
        }
        public int DoAnotherWok(int a, int b) => a > b ? a - b : b - a;
    }
}
