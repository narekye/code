using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample7
{
    public abstract class A
    {
        public virtual string Print() { return "A"; }
    }

    public class B : A
    {
        public virtual new string Print() { return "B"; }
    }

    public class C : B
    {
        public override string Print() { return "C"; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new C();
            Console.WriteLine(a.Print());

            Console.Read();
        }
    }
}
