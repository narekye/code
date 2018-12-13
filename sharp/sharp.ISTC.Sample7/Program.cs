using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp.ISTC.Sample7
{
    public abstract class BaseClass
    {
        public virtual string BaseMethod() { return $"{nameof(BaseClass)} |  {nameof(BaseMethod)}"; }
    }

    public abstract class DerivedClass : BaseClass
    {
        public virtual string BaseMethod() // does it makes sense when virtual keyowrd will be replaced with override
        {
            return $"{nameof(DerivedClass)} | {nameof(BaseMethod)}";
        }
    }

    public class Sample1 : DerivedClass
    {
        public new void BaseMethod()
        {
            Console.WriteLine("sample 1");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass b = new Sample1();

            Console.WriteLine(b.BaseMethod());

            Console.Read();
        }
    }
}
