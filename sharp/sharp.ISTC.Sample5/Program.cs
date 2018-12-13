using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample5
{
    interface IControl
    {
        void Paint();
    }

    interface IForm
    {
        void Paint();
    }

    class Implementation : IControl, IForm
    {
        public void Paint() { }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
