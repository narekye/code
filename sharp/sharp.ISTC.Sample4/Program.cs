using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample4
{
    class A
    {
        public virtual void DoWork()
        {
            Console.WriteLine($"{nameof(A)} does work!");
        }
    }

    class B : A
    {
        public override void DoWork()
        {
            Console.WriteLine($"{nameof(B)} does work!");
        }
    }

    class C : B
    {
        public override void DoWork()
        {
            Console.WriteLine($"{nameof(C)} does work!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A variable = new B();

            variable.DoWork();

            variable = new C();

            variable.DoWork();

            Console.Read();
        }
    }
}
